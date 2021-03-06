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
using Newtonsoft.Json;

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

            await PerformComputedHandling(server_snapshot, snapshot);
            await PerformPlayerInfoHandling(snapshot.profileid); //insert into "base", "ply" etc pages   

            await PerformPlayerProgressHandling(server_snapshot, snapshot);
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

                BF2142PlayerSnapshot currentSnapshot = (BF2142PlayerSnapshot)JsonConvert.DeserializeObject(data.ToJson().ToString(), typeof(BF2142PlayerSnapshot));
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

                BF2142PlayerSnapshot currentSnapshot = (BF2142PlayerSnapshot)JsonConvert.DeserializeObject(data.ToJson().ToString(), typeof(BF2142PlayerSnapshot));
                PlayerInfo_ComputedHandler.PerformComputations(server_snapshot, snapshot, currentSnapshot, _processorConfig);

                foreach(var prop in props) {
                    var attrs = prop.GetCustomAttributes(false);

                    var jsonHandler = (Newtonsoft.Json.JsonPropertyAttribute)attrs.Where(g => g.GetType() == typeof(Newtonsoft.Json.JsonPropertyAttribute)).FirstOrDefault();
                    var propName = jsonHandler?.PropertyName ?? prop.Name;
                    propName = setNamePrefix + propName;
                    StatsHandlerAttribute statsHandler = (StatsHandlerAttribute)attrs.Where(g => g.GetType() == typeof(StatsHandlerAttribute)).FirstOrDefault();
                    if(statsHandler != null) {
                        if(statsHandler.IsComputed) {
                            var value = prop.GetValue(currentSnapshot);                        
                            if(int.TryParse(value.ToString(), out int intValue)) {
                                setRecord[propName] = new BsonInt32(intValue);
                            } else if(double.TryParse(value.ToString(), out double doubleValue)) {
                                setRecord[propName] = new BsonDouble(doubleValue);
                            } else {
                                setRecord[propName] = new BsonString(value.ToString());
                            }                        
                        }                        
                    }
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
                var attrs = prop.GetCustomAttributes(false);

                var jsonHandler = (Newtonsoft.Json.JsonPropertyAttribute)attrs.Where(g => g.GetType() == typeof(Newtonsoft.Json.JsonPropertyAttribute)).FirstOrDefault();
                var propName = jsonHandler?.PropertyName ?? prop.Name;
                propName = incNamePrefix + propName;
                StatsHandlerAttribute statsHandler = (StatsHandlerAttribute)attrs.Where(g => g.GetType() == typeof(StatsHandlerAttribute)).FirstOrDefault();
                if(statsHandler != null) {
                    if(statsHandler.IsIncrement) {
                        var value = prop.GetValue(snapshot);                        
                        if(int.TryParse(value.ToString(), out int intValue)) {
                            incRecord[propName] = new BsonInt32(intValue);
                        } else if(double.TryParse(value.ToString(), out double doubleValue)) {
                            incRecord[propName] = new BsonDouble(doubleValue);
                        } else {
                            incRecord[propName] = new BsonString(value.ToString());
                        }                        
                    }                        
                }
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
                var attrs = prop.GetCustomAttributes(false);

                var jsonHandler = (Newtonsoft.Json.JsonPropertyAttribute)attrs.Where(g => g.GetType() == typeof(Newtonsoft.Json.JsonPropertyAttribute)).FirstOrDefault();
                var propName = jsonHandler?.PropertyName ?? prop.Name;
                propName = incNamePrefix + propName;
                StatsHandlerAttribute statsHandler = (StatsHandlerAttribute)attrs.Where(g => g.GetType() == typeof(StatsHandlerAttribute)).FirstOrDefault();
                if(statsHandler != null) {
                    if(statsHandler.IsGreaterEqual) {

                        var value = prop.GetValue(snapshot);
                        
                        if(int.TryParse(value.ToString(), out int intValue)) {
                            incRecord[propName] = new BsonInt32(intValue);
                        } else if(double.TryParse(value.ToString(), out double doubleValue)) {
                            incRecord[propName] = new BsonDouble(doubleValue);
                        } else {
                            incRecord[propName] = new BsonString(value.ToString());
                        }                        
                    }
                        
                }
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
                var attrs = prop.GetCustomAttributes(false);

                var jsonHandler = (Newtonsoft.Json.JsonPropertyAttribute)attrs.Where(g => g.GetType() == typeof(Newtonsoft.Json.JsonPropertyAttribute)).FirstOrDefault();
                var propName = jsonHandler?.PropertyName ?? prop.Name;
                propName = incNamePrefix + propName;
                StatsHandlerAttribute statsHandler = (StatsHandlerAttribute)attrs.Where(g => g.GetType() == typeof(StatsHandlerAttribute)).FirstOrDefault();
                if(statsHandler != null) {
                    if(statsHandler.IsSet) {

                        var value = prop.GetValue(snapshot);
                        
                        if(int.TryParse(value.ToString(), out int intValue)) {
                            incRecord[propName] = new BsonInt32(intValue);
                        } else if(double.TryParse(value.ToString(), out double doubleValue)) {
                            incRecord[propName] = new BsonDouble(doubleValue);
                        } else {
                            incRecord[propName] = new BsonString(value.ToString());
                        }
                        
                    }
                        
                }
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
                }

            }
        }
        private async Task PerformPlayerInfoHandlingForType(int profileid, string name, BsonDocument playerInfoData) {
            var key = BASE_PAGE_KEY + "_" + name;

            var type = typeof(BF2142PlayerSnapshot);
            var props = type.GetProperties();

            var setData = new BsonDocument {};

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);
                var jsonHandler = (Newtonsoft.Json.JsonPropertyAttribute)attrs.Where(g => g.GetType() == typeof(Newtonsoft.Json.JsonPropertyAttribute)).FirstOrDefault();

                var playerInfoOutput = (PlayerInfoOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerInfoOutputPageAttribute) && ((PlayerInfoOutputPageAttribute)g).PageName.Equals(name)).FirstOrDefault();
                var propName = jsonHandler?.PropertyName ?? prop.Name;
                if(playerInfoData.Contains(propName) && playerInfoOutput != null) {
                    setData[propName] = playerInfoData[propName];
                }
            }

            var updateRecord = new BsonDocument{};

            var dataRecord = new BsonDocument {};
            dataRecord["data"] = setData;
            updateRecord["$set"] = dataRecord;


            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(_processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(key)));

            await _collection.UpdateOneAsync(searchRequest, updateRecord, new UpdateOptions { IsUpsert = true});
        }
        #endregion
    }
}