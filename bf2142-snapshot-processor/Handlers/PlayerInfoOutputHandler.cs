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
    public static class PlayerInfoOutputHandler {
            const string BASE_PAGE_KEY = "player_info";
            public static async Task PerformPlayerInfoHandling(int profileid, IMongoCollection<BsonDocument> collection, ProcessorConfiguration processorConfig) {

            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(BASE_PAGE_KEY)));

            var record = await (await collection.FindAsync(searchRequest)).FirstOrDefaultAsync();

            if(record != null) {
                var data = record["data"].AsBsonDocument;


                //now that all calculations, etc are done, output to pages!
                string[] pages = new string[] {"base","ply","titan","wrk","com","ovr","comp", "veh", "wep"};
                foreach(var page in pages) {
                    await PerformPlayerInfoHandlingForType(profileid, page, data, collection, processorConfig);
                    await PerformPlayerInfoHandlingForType_Vehicles(profileid, page, data, collection, processorConfig);
                    await PerformPlayerInfoHandlingForType_Weapons(profileid, page, data, collection, processorConfig);
                }

            }
        }

        private static async Task PerformPlayerInfoHandlingForType(int profileid, string name, BsonDocument playerInfoData, IMongoCollection<BsonDocument> collection, ProcessorConfiguration processorConfig) {
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
            searchRequest.Add(new BsonElement("gameid", new BsonInt32(processorConfig.gameid)));
            searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
            searchRequest.Add(new BsonElement("pageKey", new BsonString(key)));

            if(setData.ElementCount > 0) {
                await collection.UpdateOneAsync(searchRequest, updateRecord, new UpdateOptions { IsUpsert = true});
            }
        }
        #region Player Info - Vehicle Handling
            private static Task PerformPlayerInfoHandlingForType_WriteVehicleToDocument(BsonDocument playerInfoData, BsonDocument setData, int vehicleIndex, string pageName) {
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
            private static async Task PerformPlayerInfoHandlingForType_Vehicles(int profileid, string name, BsonDocument playerInfoData, IMongoCollection<BsonDocument> collection, ProcessorConfiguration processorConfig) {
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
                searchRequest.Add(new BsonElement("gameid", new BsonInt32(processorConfig.gameid)));
                searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
                searchRequest.Add(new BsonElement("pageKey", new BsonString(key)));

                if(setData.ElementCount > 0) {
                    await collection.UpdateOneAsync(searchRequest, updateRecord, new UpdateOptions { IsUpsert = true});
                }
                
            }
            #endregion

            #region Player Info - Weapon Handling
            private static Task PerformPlayerInfoHandlingForType_WriteWeaponToDocument(BsonDocument playerInfoData, BsonDocument setData, int weaponIndex, string pageName) {
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
            private static async Task PerformPlayerInfoHandlingForType_Weapons(int profileid, string name, BsonDocument playerInfoData, IMongoCollection<BsonDocument> collection, ProcessorConfiguration processorConfig) {
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
                searchRequest.Add(new BsonElement("gameid", new BsonInt32(processorConfig.gameid)));
                searchRequest.Add(new BsonElement("profileid", new BsonInt32(profileid)));
                searchRequest.Add(new BsonElement("pageKey", new BsonString(key)));
                
                if(setData.ElementCount > 0) {
                    await collection.UpdateOneAsync(searchRequest, updateRecord, new UpdateOptions { IsUpsert = true});
                }
            }
            #endregion
    
    }
}