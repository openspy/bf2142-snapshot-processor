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
namespace BF2142.SnapshotProcessor {
    public static class PlayerInfo_ComputedHandler {

        private const string COMPUTED_PREFIX = "computed.";
        public static async Task PerformComputations(BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot, ProcessorConfiguration processorConfig, IMongoCollection<BsonDocument> collection) {

            var projectDocPhase1 = new BsonDocument {};
            projectDocPhase1["gameid"] = new BsonInt32(1);
            projectDocPhase1["profileid"] = new BsonInt32(1);
            projectDocPhase1["pageKey"] = new BsonInt32(1);
            projectDocPhase1["data"] = new BsonInt32(1);
            var projectStatementPhase1 = new BsonDocument{};
            projectStatementPhase1["$project"] = projectDocPhase1;

            IncrementTotalPlays(projectDocPhase1, snapshot);
            IncrementWinsLosses(projectDocPhase1, server_snapshot, snapshot);
            IncrementGamemodeTimes(projectDocPhase1, server_snapshot, snapshot);
            IncrementGamemodeKills(projectDocPhase1, server_snapshot, snapshot);
            SetGamemodeBestKillStreak(projectDocPhase1, server_snapshot, snapshot);
            SetBestScore(projectDocPhase1, snapshot);

            AttachKDRRatio(projectDocPhase1);
            AttachOverallAccuracy(projectDocPhase1);

            await RunMergeAggregate(projectStatementPhase1, server_snapshot, snapshot, processorConfig, collection);


            //phase 2 calculations - for things which depend on previous calculations

            var projectDocPhase2 = new BsonDocument {};
            projectDocPhase2["gameid"] = new BsonInt32(1);
            projectDocPhase2["profileid"] = new BsonInt32(1);
            projectDocPhase2["pageKey"] = new BsonInt32(1);
            projectDocPhase2["data"] = new BsonInt32(1);
            var projectStatementPhase2 = new BsonDocument{};
            projectStatementPhase2["$project"] = projectDocPhase2;

            AttachWinLossRatio(projectDocPhase2);

            await RunMergeAggregate(projectStatementPhase2, server_snapshot, snapshot, processorConfig, collection);
        }
        private static async Task RunMergeAggregate(BsonDocument projectStatement, BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot, ProcessorConfiguration processorConfig, IMongoCollection<BsonDocument> collection) {
            var aggregate = new BsonDocument[4];

            var matchDoc = new BsonDocument {};
            matchDoc["gameid"] = new BsonInt32(processorConfig.gameid);
            matchDoc["profileid"] = new BsonInt32(snapshot.profileid);
            matchDoc["pageKey"] = new BsonString(PlayerSnapshotHandler.BASE_PAGE_KEY);

            var matchStatement = new BsonDocument{};
            matchStatement["$match"] = matchDoc;
            aggregate[0] = matchStatement;
            aggregate[1] = projectStatement;


            var projectStatementStage2 =  BsonSerializer.Deserialize<BsonDocument>("{$project: {gameid: 1, profileid: 1, pageKey: 1, data:{ $mergeObjects: [\"$data\", \"$computed\"]}}}");

            aggregate[2] = projectStatementStage2;

            var mergeStatement = BsonSerializer.Deserialize<BsonDocument>("{$merge: {into: \"player_progress\", on: [\"gameid\",\"profileid\",\"pageKey\"], whenMatched: \"merge\", whenNotMatched: \"fail\" }}");
            aggregate[3] = mergeStatement;

            PipelineDefinition<BsonDocument, BsonDocument> pipeline = aggregate;
            await collection.AggregateAsync(pipeline);
        }
        private static void SetBestScore(BsonDocument projectDocument, BF2142PlayerSnapshot snapshot) {
            var condData = new BsonDocument {};
            var ifContent = new BsonDocument {};

            var gtArray = new BsonArray();
            gtArray.Add(new BsonInt32(snapshot.global_score));
            gtArray.Add(new BsonString("$data.brs"));
            ifContent["$gt"] = gtArray;
            condData["if"] = ifContent;
            condData["then"] = new BsonInt32(snapshot.global_score);
            condData["else"] = new BsonString("$data.brs");

            var condStatement = new BsonDocument{};
            condStatement["$cond"] = condData;

            projectDocument[COMPUTED_PREFIX + "brs"] = condStatement;
        }
        private static void IncrementTotalPlays(BsonDocument projectDocument, BF2142PlayerSnapshot snapshot) {
             string key = "attp-0";
            switch(snapshot.team) {
                case 1: //PAC
                    
                break;
                case 2: //EU
                    key = "attp-1";
                    break;

            }

            var addArray = new BsonArray();
            AddPropertyToArray_WithNullCheck("$data." + key, addArray);
            addArray.Add(new BsonInt32(1));

            var addStatement = new BsonDocument {};
            addStatement["$add"] = addArray;

            projectDocument[COMPUTED_PREFIX + key] = addStatement;
        }
        private static void AddPropertyToArray_WithNullCheck(string name, BsonArray array) {
            var ifNullParams = new BsonArray();

            ifNullParams.Add(new BsonString(name));
            ifNullParams.Add(new BsonInt32(0));

            var ifNullDocument = new BsonDocument{};

            ifNullDocument["$ifNull"] = ifNullParams;

            array.Add(ifNullDocument);
            
        }
        private static void IncrementWinsLosses(BsonDocument projectDocument, BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {
            bool player_won = snapshot.team == server_snapshot.game_properties.winning_team;
            string key = "win";
            if(!player_won) {
                key = "los";
            }

            var addArray = new BsonArray();
            AddPropertyToArray_WithNullCheck("$data." + key, addArray);
            addArray.Add(new BsonInt32(1));

            var addStatement = new BsonDocument {};
            addStatement["$add"] = addArray;

            projectDocument[COMPUTED_PREFIX + key] = addStatement;
        }
        private static void IncrementGamemodeKills(BsonDocument projectDocument, BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {
            string key = string.Format("kgpm-{0}", server_snapshot.game_properties.gamemode);
            
            var addArray = new BsonArray();
            AddPropertyToArray_WithNullCheck("$data." + key, addArray);
            addArray.Add(new BsonInt32(1));

            var addStatement = new BsonDocument {};
            addStatement["$add"] = addArray;

            projectDocument[COMPUTED_PREFIX + key] = addStatement;
            
        }

        private static void SetGamemodeBestKillStreak(BsonDocument projectDocument, BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {
            string key = string.Format("bksgpm-{0}", server_snapshot.game_properties.gamemode);
            
            var condData = new BsonDocument {};
            var ifContent = new BsonDocument {};

            var gtArray = new BsonArray();
            gtArray.Add(new BsonInt32(snapshot.global_score));
            gtArray.Add(new BsonString("$data." + key));
            ifContent["$gt"] = gtArray;
            condData["if"] = ifContent;
            condData["then"] = new BsonInt32(snapshot.global_score);
            condData["else"] = new BsonString("$data." + key);

            var condStatement = new BsonDocument{};
            condStatement["$cond"] = condData;

            projectDocument[COMPUTED_PREFIX + key] = condStatement;
            
        }

        private static void IncrementGamemodeTimes(BsonDocument projectDocument, BF2142Snapshot server_snapshot, BF2142PlayerSnapshot snapshot) {

            string tacKey = string.Format("csgpm-{0}", server_snapshot.game_properties.gamemode);
            string csKey = string.Format("ctgpm-{0}", server_snapshot.game_properties.gamemode);
       


            //tacKey
            var addArray = new BsonArray();
            AddPropertyToArray_WithNullCheck("$data." + tacKey, addArray);
            addArray.Add(new BsonInt32(snapshot.time_as_commander));

            var addStatement = new BsonDocument {};
            addStatement["$add"] = addArray;

            projectDocument[COMPUTED_PREFIX + tacKey] = addStatement;

            //csKey
            addArray = new BsonArray();
            addArray.Add(new BsonString("$data." + csKey));
            addArray.Add(new BsonDouble(snapshot.commander_score));

            addStatement = new BsonDocument {};
            addStatement["$add"] = addArray;

            projectDocument[COMPUTED_PREFIX + csKey] = addStatement;

        }

        private static void AttachWinLossRatio(BsonDocument projectDocument) {
            var divArray = new BsonArray {};
            divArray.Add(new BsonString("$data.win"));
            divArray.Add(new BsonString("$data.los"));

            var divDoc = new BsonDocument {};
            divDoc["$divide"] = divArray;

            var condData = new BsonDocument {};
            var ifContent = new BsonDocument {};

            var gtArray = new BsonArray();
            gtArray.Add(new BsonString("$data.los"));
            gtArray.Add(new BsonInt32(0));
            ifContent["$gt"] = gtArray;
            condData["if"] = ifContent;
            condData["then"] = divDoc;
            condData["else"] = new BsonInt32(0);

            var condStatement = new BsonDocument{};
            condStatement["$cond"] = condData;

            projectDocument[COMPUTED_PREFIX + "wlr"] = condStatement;
        }

        private static void AttachKDRRatio(BsonDocument projectDocument) {
            var divArray = new BsonArray {};
            divArray.Add(new BsonString("$data.klls"));
            divArray.Add(new BsonString("$data.dths"));

            var divDoc = new BsonDocument {};
            divDoc["$divide"] = divArray;

            var condData = new BsonDocument {};
            var ifContent = new BsonDocument {};

            var gtArray = new BsonArray();
            gtArray.Add(new BsonString("$data.dths"));
            gtArray.Add(new BsonInt32(0));
            ifContent["$gt"] = gtArray;
            condData["if"] = ifContent;
            condData["then"] = divDoc;
            condData["else"] = new BsonInt32(0);

            var condStatement = new BsonDocument{};
            condStatement["$cond"] = condData;

            projectDocument[COMPUTED_PREFIX + "kdr"] = condStatement;

        }
        private static void AttachOverallAccuracy(BsonDocument projectDocument) {
            var divArray = new BsonArray {};
            divArray.Add(new BsonString("$data.toth"));
            divArray.Add(new BsonString("$data.tots"));

            var divDoc = new BsonDocument {};
            divDoc["$divide"] = divArray;

            var condData = new BsonDocument {};
            var ifContent = new BsonDocument {};

            var gtArray = new BsonArray();
            gtArray.Add(new BsonString("$data.tots"));
            gtArray.Add(new BsonInt32(0));
            ifContent["$gt"] = gtArray;
            condData["if"] = ifContent;
            condData["then"] = divDoc;
            condData["else"] = new BsonInt32(0);

            var condStatement = new BsonDocument{};
            condStatement["$cond"] = condData;

            projectDocument[COMPUTED_PREFIX + "ovaccu"] = condStatement;
        }
    }
}