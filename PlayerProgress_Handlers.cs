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
    public static class PlayerProgress_Handlers {

        private const int MAX_PROGRESS_ELEMENTS = 50; //XXX: make this configurable
        private const string PLAYER_PROGRESS_BASEKEY = "player_progress_";
        public static async Task PerformComputations(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot gameserverSnapshot, BF2142PlayerSnapshot currentPlayerInfo, ProcessorConfiguration processorConfig, IMongoCollection<BsonDocument> collection)
        {
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "point");
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "score");
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "ttp"); 
            //await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "kills"); //xxx: DO this
            //await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "spm"); //xxx: DO this
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "role");
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "flag");
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "waccu");
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "wl");
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "twsc");
            await ComputePage(server_snapshot, gameserverSnapshot, currentPlayerInfo, processorConfig, collection, "sup");
        }
        private static async Task ComputePage(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot gameserverSnapshot, BF2142PlayerSnapshot currentPlayerInfo, ProcessorConfiguration processorConfig, IMongoCollection<BsonDocument> collection, string pageName) {
            var updateDocument = GetUpdateDocument("data.$.", pageName, currentPlayerInfo);
            //try perform update

            var date = GetDateFromRecord(server_snapshot);

            if(!await PerformUpdate(pageName, gameserverSnapshot.profileid, processorConfig.gameid, date, collection, updateDocument)) {
                var insertDocument = GetUpdateDocument("", pageName, currentPlayerInfo);
                await PerformInsert(pageName, gameserverSnapshot.profileid, processorConfig.gameid, date, collection, insertDocument);
            }
        }
        static async Task PerformInsert(string pageName, int profileid, int gameid, int timestamp, IMongoCollection<BsonDocument> collection, BsonDocument updateDocument) {
            var parentMatch = new BsonDocument{};
            parentMatch["gameid"] = new BsonInt32(gameid);
            parentMatch["profileid"] = new BsonInt32(profileid);
            parentMatch["pageKey"] = new BsonString(PLAYER_PROGRESS_BASEKEY + pageName);


            var dataElement = new BsonDocument {
                
            };

            updateDocument["date"] = new BsonInt32(timestamp);

            var eachValue = new BsonArray();
            eachValue.Add(updateDocument);

            var dataValue = new BsonDocument {
                
            };
            dataValue["$each"] = eachValue;
            dataValue["$slice"] = new BsonInt32(-MAX_PROGRESS_ELEMENTS);

            var sortValue = new BsonDocument {

            };
            sortValue["date"] = new BsonInt32(-1);
            dataValue["$sort"] = sortValue;

            dataElement["data"] = dataValue;

            var pushElement = new BsonDocument{};

            pushElement["$push"] = dataElement;

            await collection.UpdateOneAsync(parentMatch, pushElement, new UpdateOptions { IsUpsert = true});
        }
        static async Task<bool> PerformUpdate(string pageName, int profileid, int gameid, int timestamp, IMongoCollection<BsonDocument> collection, BsonDocument updateDocument) {

            var parentMatch = new BsonDocument{};
            parentMatch["gameid"] = new BsonInt32(gameid);
            parentMatch["profileid"] = new BsonInt32(profileid);
            parentMatch["pageKey"] = new BsonString(PLAYER_PROGRESS_BASEKEY + pageName);

            var elemMatch = new BsonDocument {

            };
            elemMatch["date"] = new BsonInt32(timestamp);

            var dataMatch = new BsonDocument {};
            dataMatch["$elemMatch"] = elemMatch;

            var arrayMatch = new BsonDocument{};
            arrayMatch["data"] = dataMatch;

            var andMatch = new BsonArray();
            andMatch.Add(parentMatch);
            andMatch.Add(arrayMatch);

            var whereStatement = new BsonDocument{};
            whereStatement["$and"] = andMatch;


            var incStatement = new BsonDocument {};
            incStatement["$inc"] = updateDocument;

            var result = await collection.UpdateOneAsync(whereStatement, incStatement);
            return result.MatchedCount > 0;
        }
        static BsonDocument GetUpdateDocument(string prefix, string pageName, BF2142PlayerSnapshot currentPlayerInfo) {
            var record = new BsonDocument {

            };

            var type = currentPlayerInfo.GetType();
            var props = type.GetProperties();

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);

                var outputAttribute = (PlayerProgressOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerProgressOutputPageAttribute) && ((PlayerProgressOutputPageAttribute)g).PageName.Equals(pageName)).FirstOrDefault();

                if(outputAttribute == null) continue;

                var variableName = prefix + outputAttribute.VariableName;

                var value = prop.GetValue(currentPlayerInfo);                        
                if(int.TryParse(value.ToString(), out int intValue)) {
                    record[variableName] = new BsonInt32(intValue);
                } else if(double.TryParse(value.ToString(), out double doubleValue)) {
                    record[variableName] = new BsonDouble(doubleValue);
                } else {
                    record[variableName] = new BsonString(value.ToString());
                } 
            }

            return record;
        }

        static int GetDateFromRecord(BF2142Snapshot server_snapshot) {
            var date = (int)Math.Floor(server_snapshot.game_properties.map_end_time);
            System.DateTime dtDateTime = DateTime.UnixEpoch;
            dtDateTime = dtDateTime.AddSeconds( date ).ToLocalTime();
            return (Int32)(dtDateTime.Date.Subtract(DateTime.UnixEpoch)).TotalSeconds;
        }
    }
}