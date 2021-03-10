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
            public static async Task PerformPlayerInfoHandling(int profileid, IMongoCollection<BsonDocument> collection, ProcessorConfiguration processorConfig) {
                //now that all calculations, etc are done, output to pages!
                string[] pages = new string[] {"base","ply","titan","wrk","com","ovr","comp", "veh", "wep"};
                foreach(var page in pages) {
                    var projectData = new BsonDocument {};
                    projectData["gameid"] = new BsonInt32(1);
                    projectData["pageKey"] = new BsonString(PlayerSnapshotHandler.BASE_PAGE_KEY + "_" + page);
                    projectData["profileid"] = new BsonInt32(1);
                    projectData["_id"] = new BsonInt32(0);
                    PerformPlayerInfoHandlingForType(profileid, page, projectData);
                    PerformPlayerInfoHandlingForType_Vehicles(profileid, page, projectData);
                    PerformPlayerInfoHandlingForType_Weapons(profileid, page, projectData);

                    await WriteProjectionToPage(page, profileid, projectData, processorConfig, collection);
                }
        }

        private static async Task WriteProjectionToPage(string pageName, int profileid, BsonDocument projectionRecord, ProcessorConfiguration processorConfig, IMongoCollection<BsonDocument> collection) {
            var aggregate = new BsonDocument[3];

            var matchRecord = new BsonDocument {};
            matchRecord["pageKey"] = new BsonString(PlayerSnapshotHandler.BASE_PAGE_KEY);
            matchRecord["gameid"] = new BsonInt32(processorConfig.gameid);
            matchRecord["profileid"] = new BsonInt32(profileid);

            var match = new BsonDocument {};
            match["$match"] = matchRecord;

            aggregate[0] = match;

            var projection = new BsonDocument {};
            projection["$project"] = projectionRecord;
            aggregate[1] = projection;

            var mergeRecord = new BsonDocument{};

            var merge = new BsonDocument {};
            merge["into"] = new BsonString(processorConfig.collectionName);

            var on = new BsonArray();
            on.Add(new BsonString("gameid"));
            on.Add(new BsonString("pageKey"));
            on.Add(new BsonString("profileid"));
            merge["on"] = on;
            merge["whenMatched"] = new BsonString("replace");
            merge["whenNotMatched"] = new BsonString("insert");

            mergeRecord["$merge"] = merge;

            aggregate[2] = mergeRecord;

            PipelineDefinition<BsonDocument, BsonDocument> pipeline = aggregate;
            await collection.AggregateAsync(pipeline);
        }

        private static void PerformPlayerInfoHandlingForType(int profileid, string name, BsonDocument projectionData) {
            var key = PlayerSnapshotHandler.BASE_PAGE_KEY + "_" + name;

            var type = typeof(BF2142PlayerSnapshot);
            var props = type.GetProperties();

            

            foreach(var prop in props) {
                var attrs = prop.GetCustomAttributes(false);

                var vehicleAttribute = (VehicleAttribute)attrs.Where(g => g.GetType() == typeof(VehicleAttribute)).FirstOrDefault();
                var weaponAttribute = (WeaponAttribute)attrs.Where(g => g.GetType() == typeof(WeaponAttribute)).FirstOrDefault();
                if(vehicleAttribute != null || weaponAttribute != null) continue;

                var jsonHandler = (JsonPropertyNameAttribute)attrs.Where(g => g.GetType() == typeof(JsonPropertyNameAttribute)).FirstOrDefault();

                var playerInfoOutput = (PlayerInfoOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerInfoOutputPageAttribute) && ((PlayerInfoOutputPageAttribute)g).PageName.Equals(name)).FirstOrDefault();
                var propName = jsonHandler?.Name ?? prop.Name;
                if(playerInfoOutput != null) {
                    projectionData["data." + propName] = new BsonInt32(1);
                }
            }
        }

        #region Player Info - Vehicle Handling
            private static void PerformPlayerInfoHandlingForType_WriteVehicleToDocument(BsonDocument projectionData, int vehicleIndex, string pageName) {
                var type = typeof(BF2142Vehicle);

                var props = type.GetProperties();

                var prefix = "v";

                var suffix = "-" + vehicleIndex.ToString();

                foreach(var prop in props) {
                    var attrs = prop.GetCustomAttributes(false);
                    var jsonHandler = (JsonPropertyNameAttribute)attrs.Where(g => g.GetType() == typeof(JsonPropertyNameAttribute)).FirstOrDefault();

                    var playerInfoOutput = (PlayerInfoOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerInfoOutputPageAttribute) && ((PlayerInfoOutputPageAttribute)g).PageName.Equals(pageName)).FirstOrDefault();

                    var propName = prefix + (jsonHandler?.Name ?? prop.Name) + suffix;

                    if(playerInfoOutput != null) {
                        projectionData["data." + propName] = new BsonInt32(1);
                    }
                }
            }
            private static void PerformPlayerInfoHandlingForType_Vehicles(int profileid, string name, BsonDocument projectionData) {
                var key = PlayerSnapshotHandler.BASE_PAGE_KEY + "_" + name;

                var type = typeof(BF2142PlayerSnapshot);
                var props = type.GetProperties();

                foreach(var prop in props) {
                    var attrs = prop.GetCustomAttributes(false);

                    var vehicleAttribute = (VehicleAttribute)attrs.Where(g => g.GetType() == typeof(VehicleAttribute)).FirstOrDefault();
                    if(vehicleAttribute == null) continue;

                    PerformPlayerInfoHandlingForType_WriteVehicleToDocument(projectionData, vehicleAttribute.VehicleId, name);
                }
                
            }
            #endregion
        #region Player Info - Weapon Handling
            private static void PerformPlayerInfoHandlingForType_WriteWeaponToDocument(BsonDocument projectionData, int weaponIndex, string pageName) {
                var type = typeof(BF2142Weapon);

                var props = type.GetProperties();

                var prefix = "w";

                var suffix = "-" + weaponIndex.ToString();

                foreach(var prop in props) {
                    var attrs = prop.GetCustomAttributes(false);
                    var jsonHandler = (JsonPropertyNameAttribute)attrs.Where(g => g.GetType() == typeof(JsonPropertyNameAttribute)).FirstOrDefault();

                    var playerInfoOutput = (PlayerInfoOutputPageAttribute)attrs.Where(g => g.GetType() == typeof(PlayerInfoOutputPageAttribute) && ((PlayerInfoOutputPageAttribute)g).PageName.Equals(pageName)).FirstOrDefault();

                    var propName = prefix + (jsonHandler?.Name ?? prop.Name) + suffix;

                    if(playerInfoOutput != null) {
                        projectionData["data." + propName] = new BsonInt32(1);
                    }
                }
            }
            private static void PerformPlayerInfoHandlingForType_Weapons(int profileid, string name, BsonDocument projectionData) {
                var key = PlayerSnapshotHandler.BASE_PAGE_KEY + "_" + name;

                var type = typeof(BF2142PlayerSnapshot);
                var props = type.GetProperties();

                var setData = new BsonDocument {};

                foreach(var prop in props) {
                    var attrs = prop.GetCustomAttributes(false);

                    var weaponAttribute = (WeaponAttribute)attrs.Where(g => g.GetType() == typeof(WeaponAttribute)).FirstOrDefault();
                    if(weaponAttribute == null) continue;

                    PerformPlayerInfoHandlingForType_WriteWeaponToDocument(projectionData, weaponAttribute.WeaponId, name);
                }
            }
            #endregion
    }
}