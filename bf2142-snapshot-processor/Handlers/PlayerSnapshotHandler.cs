using System;
using System.Threading;
using System.Collections.Generic; 
using QueueProcessor;
using QueueProcessor.Utils;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BF2142.SnapshotProcessor {
    public class PlayerSnapshotHandler {
        private readonly ProcessorConfiguration _processorConfig;
        private readonly IMongoDatabase _database;
        private readonly IPersistentStorage _persistentStorage;
        private readonly ILogger<PlayerSnapshotHandler> _logger;
        private readonly IMongoCollection<BsonDocument> _collection;

        public const string BASE_PAGE_KEY = "player_info";
        public PlayerSnapshotHandler(BF2142.SnapshotProcessor.ProcessorConfiguration processorConfig, IMongoDatabase database, IPersistentStorage persistentStorage, ILogger<PlayerSnapshotHandler> logger) {
             _processorConfig = processorConfig;
             _database = database;
             _persistentStorage = persistentStorage;
             _logger = logger;

             _collection = _database.GetCollection<BsonDocument>("player_progress");
        }
        public async Task HandlePlayerSnapshot(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {
            await PerformIncrements(snapshot);
            await PerformGreaterThans(snapshot);
            await PerformSets(snapshot);

            await PlayerInfo_ComputedHandler.PerformComputations(server_snapshot, snapshot,  _processorConfig, _collection);
            await PlayerInfoOutputHandler.PerformPlayerInfoHandling(snapshot.profileid, _collection, _processorConfig); //insert into "base", "ply" etc pages   

            await PerformPlayerProgressHandling(server_snapshot, snapshot);

            //await PerformAwardHandling(server_snapshot, snapshot);
        }
        private async Task PerformAwardHandling(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {
            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(snapshot.profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(BASE_PAGE_KEY)));

            var record = await (await _collection.FindAsync(searchRequest)).FirstOrDefaultAsync();
            if(record != null) {
                var data = record["data"].AsBsonDocument;

                BF2142PlayerSnapshot currentSnapshot = (BF2142PlayerSnapshot)JsonSerializer.Deserialize(data.ToJson().ToString(), typeof(BF2142PlayerSnapshot));
                await AwardsHandler.PerformHandling(snapshot, currentSnapshot, _collection, _processorConfig);
                
            }
        }
        private async Task PerformPlayerProgressHandling(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {
            var type = snapshot.GetType();
            var props = type.GetProperties();

            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(snapshot.profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(BASE_PAGE_KEY)));

            var record = await (await _collection.FindAsync(searchRequest)).FirstOrDefaultAsync();
            if(record != null) {
                var data = record["data"].AsBsonDocument;

                BF2142PlayerSnapshot currentSnapshot = (BF2142PlayerSnapshot)JsonSerializer.Deserialize(data.ToJson().ToString(), typeof(BF2142PlayerSnapshot), new JsonSerializerOptions { 
                    IgnoreNullValues = true
                });
                await PlayerProgress_Handlers.PerformComputations(server_snapshot, snapshot, currentSnapshot, _processorConfig, _collection);
            }
        }
        #region PerformIncrements
        private async Task PerformIncrements(BF2142PlayerSnapshot snapshot) {
            var type = snapshot.GetType();
            var props = type.GetProperties();

            var incRecord = new BsonDocument {

            };
            var incNamePrefix = "data.";

            foreach(var prop in props) {
                HandleProperty(prop, incRecord, incNamePrefix, snapshot, true, false, false, false);
            }
            var updateRecord = new BsonDocument {};
            updateRecord["$inc"] = incRecord;

            var searchRecord = new BsonDocument{};
            searchRecord["gameid"] = _processorConfig.gameid;
            searchRecord["profileid"] = snapshot.profileid;
            searchRecord["pageKey"] = BASE_PAGE_KEY;

            await _collection.UpdateOneAsync(searchRecord, updateRecord, new UpdateOptions { IsUpsert = true});
        }
        #endregion
        #region PerformGreaterThans
        private async Task PerformGreaterThans(BF2142PlayerSnapshot snapshot) {
            var type = snapshot.GetType();
            var props = type.GetProperties();

            var incRecord = new BsonDocument {

            };
            var incNamePrefix = "data.";

            foreach(var prop in props) {
                HandleProperty(prop, incRecord, incNamePrefix, snapshot, false, false, false, true);
            }
            var updateRecord = new BsonDocument {};
            updateRecord["$max"] = incRecord;

            var searchRecord = new BsonDocument{};
            searchRecord["gameid"] = _processorConfig.gameid;
            searchRecord["profileid"] = snapshot.profileid;
            searchRecord["pageKey"] = BASE_PAGE_KEY;

            await _collection.UpdateOneAsync(searchRecord, updateRecord, new UpdateOptions { IsUpsert = true});
        }
        #endregion
        #region PerformSets
        private async Task PerformSets(BF2142PlayerSnapshot snapshot) {
            var type = snapshot.GetType();
            var props = type.GetProperties();

            var incRecord = new BsonDocument {

            };
            var incNamePrefix = "data.";

            foreach(var prop in props) {
                HandleProperty(prop, incRecord, incNamePrefix, snapshot, false, true, false, false);
            }
            var updateRecord = new BsonDocument {};
            updateRecord["$set"] = incRecord;

            var searchRecord = new BsonDocument{};
            searchRecord["gameid"] = _processorConfig.gameid;
            searchRecord["profileid"] = snapshot.profileid;
            searchRecord["pageKey"] = BASE_PAGE_KEY;

            await _collection.UpdateOneAsync(searchRecord, updateRecord, new UpdateOptions { IsUpsert = true});
        }
        #endregion


        private void HandleProperty(System.Reflection.PropertyInfo property, BsonDocument record, string prefix, object instance,
            bool IsIncrement, bool IsSet, bool IsComputed, bool IsGreaterEqual, string suffix = "") {
            var attrs = property.GetCustomAttributes(false);

            var vehicleAttribute = (VehicleAttribute)attrs.Where(g => g.GetType() == typeof(VehicleAttribute)).FirstOrDefault();
            var weaponAttribute = (WeaponAttribute)attrs.Where(g => g.GetType() == typeof(WeaponAttribute)).FirstOrDefault();

            if(vehicleAttribute != null) {
                var vehicleInfo = property.GetValue(instance);
                if(vehicleInfo != null) {
                    var type = typeof(BF2142Vehicle);
                    var childProps = type.GetProperties();

                    var vehiclePrefix = prefix + "v";

                    var vehicleSuffix = "-" + vehicleAttribute.VehicleId.ToString();
                    foreach(var childProp in childProps) {
                        HandleProperty(childProp, record, vehiclePrefix, vehicleInfo, IsIncrement, IsSet, IsComputed, IsGreaterEqual, vehicleSuffix);
                    }
                }
                return;
            } else if(weaponAttribute != null) {
                var weaponInfo = property.GetValue(instance);
                if(weaponInfo != null) {
                    var type = typeof(BF2142Weapon);
                    var childProps = type.GetProperties();

                    var weaponPrefix = prefix + "w";

                    var weaponSuffix = "-" + weaponAttribute.WeaponId.ToString();
                    foreach(var childProp in childProps) {
                        HandleProperty(childProp, record, weaponPrefix, weaponInfo, IsIncrement, IsSet, IsComputed, IsGreaterEqual, weaponSuffix);
                    }
                }
                return;
            }

            var jsonHandler = (JsonPropertyNameAttribute)attrs.Where(g => g.GetType() == typeof(JsonPropertyNameAttribute)).FirstOrDefault();
            var propName = jsonHandler?.Name ?? property.Name;
            propName = prefix + propName + suffix;
            StatsHandlerAttribute statsHandler = (StatsHandlerAttribute)attrs.Where(g => g.GetType() == typeof(StatsHandlerAttribute)).FirstOrDefault();
            if(statsHandler != null) {
                if((IsIncrement && statsHandler.IsIncrement) || (IsSet && statsHandler.IsSet) || (IsComputed && statsHandler.IsComputed) || (IsGreaterEqual && statsHandler.IsGreaterEqual)) {
                    var value = property.GetValue(instance);                        
                    if(int.TryParse(value.ToString(), out int intValue)) {
                        record[propName] = new BsonInt32(intValue);
                    } else if(double.TryParse(value.ToString(), out double doubleValue)) {
                        record[propName] = new BsonDouble(doubleValue);
                    } else {
                        record[propName] = new BsonString(value.ToString());
                    }                        
                }                        
            }
        }
    }
}