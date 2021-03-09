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

        const string BASE_PAGE_KEY = "player_info";
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

            //await PerformComputedHandling(server_snapshot, snapshot);
            await PerformPlayerInfoHandling(snapshot.profileid); //insert into "base", "ply" etc pages   

            //await PerformPlayerProgressHandling(server_snapshot, snapshot);

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

                BF2142PlayerSnapshot currentSnapshot = (BF2142PlayerSnapshot)JsonSerializer.Deserialize(data.ToJson().ToString(), typeof(BF2142PlayerSnapshot));
                await PlayerProgress_Handlers.PerformComputations(server_snapshot, snapshot, currentSnapshot, _processorConfig, _collection);
            }
        }
        private async Task PerformComputedHandling(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {

            var type = snapshot.GetType();
            var props = type.GetProperties();

            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(snapshot.profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(BASE_PAGE_KEY)));

            var setRecord = new BsonDocument {

            };
            var setNamePrefix = "data.";

            var record = await (await _collection.FindAsync(searchRequest)).FirstOrDefaultAsync();

            if(record != null) {
                var data = record["data"].AsBsonDocument;

                BF2142PlayerSnapshot currentSnapshot = (BF2142PlayerSnapshot)JsonSerializer.Deserialize(data.ToJson().ToString(), typeof(BF2142PlayerSnapshot));
                PlayerInfo_ComputedHandler.PerformComputations(server_snapshot, snapshot, currentSnapshot, _processorConfig);

                foreach(var prop in props) {
                    HandleProperty(prop, setRecord, setNamePrefix, currentSnapshot, false, false, true, false);
                }

                var updateRecord = new BsonDocument {};
                updateRecord["$set"] = setRecord;

                var searchRecord = new BsonDocument{};
                searchRecord["gameid"] = _processorConfig.gameid;
                searchRecord["profileid"] = snapshot.profileid;
                searchRecord["pageKey"] = BASE_PAGE_KEY;

                await _collection.UpdateOneAsync(searchRecord, updateRecord, new UpdateOptions { IsUpsert = true});
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
        #region PerformPlayerInfoHandling

        private async Task PerformPlayerInfoHandling(int profileid) {

            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(BASE_PAGE_KEY)));

            var record = await (await _collection.FindAsync(searchRequest)).FirstOrDefaultAsync();

            if(record != null) {
                var data = record["data"].AsBsonDocument;


                //now that all calculations, etc are done, output to pages!
                string[] pages = new string[] {"base","ply","titan","wrk","com","ovr","comp", "veh", "wep"};
                foreach(var page in pages) {
                    await PerformPlayerInfoHandlingForType(profileid, page, data);
                    await PerformPlayerInfoHandlingForType_Vehicles(profileid, page, data);
                    await PerformPlayerInfoHandlingForType_Weapons(profileid, page, data);
                }

            }
        }

        #region Player Info - Vehicle Handling
        private Task PerformPlayerInfoHandlingForType_WriteVehicleToDocument(BsonDocument playerInfoData, BsonDocument setData, int vehicleIndex, string pageName) {
            var type = typeof(BF2142Vehicle);

            var props = type.GetProperties();

            var prefix = "v";

            var suffix = "-" + vehicleIndex.ToString();

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);
                var jsonHandler = (JsonPropertyNameAttribute)attrs.Where(g => g.GetType() == typeof(JsonPropertyNameAttribute)).FirstOrDefault();

                var playerInfoOutput = (PlayerInfoOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerInfoOutputPageAttribute) && ((PlayerInfoOutputPageAttribute)g).PageName.Equals(pageName)).FirstOrDefault();

                var propName = prefix + (jsonHandler?.Name ?? prop.Name) + suffix;

                if(playerInfoData.Contains(propName) && playerInfoOutput != null) {
                    setData["data." + propName] = playerInfoData[propName];
                }
            }

            return Task.CompletedTask;
        }
        private async Task PerformPlayerInfoHandlingForType_Vehicles(int profileid, string name, BsonDocument playerInfoData) {
            var key = BASE_PAGE_KEY + "_" + name;

            var type = typeof(BF2142PlayerSnapshot);
            var props = type.GetProperties();

            var setData = new BsonDocument {};

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);

                var vehicleAttribute = (VehicleAttribute)attrs.Where(g => g.GetType() == typeof(VehicleAttribute)).FirstOrDefault();
                if(vehicleAttribute == null) continue;

                await PerformPlayerInfoHandlingForType_WriteVehicleToDocument(playerInfoData, setData, vehicleAttribute.VehicleId, name);
            }

            var updateRecord = new BsonDocument{};

            updateRecord["$set"] = setData;


            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(key)));

            if(setData.ElementCount > 0) {
                await _collection.UpdateOneAsync(searchRequest, updateRecord, new UpdateOptions { IsUpsert = true});
            }
            
        }
        #endregion


        #region Player Info - Weapon Handling
        private Task PerformPlayerInfoHandlingForType_WriteWeaponToDocument(BsonDocument playerInfoData, BsonDocument setData, int weaponIndex, string pageName) {
            var type = typeof(BF2142Weapon);

            var props = type.GetProperties();

            var prefix = "w";

            var suffix = "-" + weaponIndex.ToString();

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);
                var jsonHandler = (JsonPropertyNameAttribute)attrs.Where(g => g.GetType() == typeof(JsonPropertyNameAttribute)).FirstOrDefault();

                var playerInfoOutput = (PlayerInfoOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerInfoOutputPageAttribute) && ((PlayerInfoOutputPageAttribute)g).PageName.Equals(pageName)).FirstOrDefault();

                var propName = prefix + (jsonHandler?.Name ?? prop.Name) + suffix;

                if(playerInfoData.Contains(propName) && playerInfoOutput != null) {
                    setData["data." + propName] = playerInfoData[propName];
                }
            }

            return Task.CompletedTask;
        }
        private async Task PerformPlayerInfoHandlingForType_Weapons(int profileid, string name, BsonDocument playerInfoData) {
            var key = BASE_PAGE_KEY + "_" + name;

            var type = typeof(BF2142PlayerSnapshot);
            var props = type.GetProperties();

            var setData = new BsonDocument {};

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);

                var weaponAttribute = (WeaponAttribute)attrs.Where(g => g.GetType() == typeof(WeaponAttribute)).FirstOrDefault();
                if(weaponAttribute == null) continue;

                await PerformPlayerInfoHandlingForType_WriteWeaponToDocument(playerInfoData, setData, weaponAttribute.WeaponId, name);
            }

            var updateRecord = new BsonDocument{};

            updateRecord["$set"] = setData;


            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(key)));
            
            if(setData.ElementCount > 0) {
                await _collection.UpdateOneAsync(searchRequest, updateRecord, new UpdateOptions { IsUpsert = true});
            }
        }
        #endregion
        private async Task PerformPlayerInfoHandlingForType(int profileid, string name, BsonDocument playerInfoData) {
            var key = BASE_PAGE_KEY + "_" + name;

            var type = typeof(BF2142PlayerSnapshot);
            var props = type.GetProperties();

            var setData = new BsonDocument {};

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);

                var vehicleAttribute = (VehicleAttribute)attrs.Where(g => g.GetType() == typeof(VehicleAttribute)).FirstOrDefault();
                var weaponAttribute = (WeaponAttribute)attrs.Where(g => g.GetType() == typeof(WeaponAttribute)).FirstOrDefault();
                if(vehicleAttribute != null || weaponAttribute != null) continue;

                var jsonHandler = (JsonPropertyNameAttribute)attrs.Where(g => g.GetType() == typeof(JsonPropertyNameAttribute)).FirstOrDefault();

                var playerInfoOutput = (PlayerInfoOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerInfoOutputPageAttribute) && ((PlayerInfoOutputPageAttribute)g).PageName.Equals(name)).FirstOrDefault();
                var propName = jsonHandler?.Name ?? prop.Name;
                if(playerInfoData.Contains(propName) && playerInfoOutput != null) {
                    setData["data." + propName] = playerInfoData[propName];
                }
            }

            var updateRecord = new BsonDocument{};

            updateRecord["$set"] = setData;


            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(key)));

            if(setData.ElementCount > 0) {
                await _collection.UpdateOneAsync(searchRequest, updateRecord, new UpdateOptions { IsUpsert = true});
            }
        }


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
        #endregion
    }
}