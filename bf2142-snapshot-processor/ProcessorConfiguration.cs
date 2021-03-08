using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic; 
using MongoDB.Driver;
using MongoDB.Bson;

using MongoDB.Bson.Serialization;
namespace BF2142.SnapshotProcessor {
    public class RankScoreItem {
        public int rank {get; set;}
        public int minScore {get; set;}
    }
    public class AwardConfigItem {
        public string awardKey {get; set;}
        public List<string> awardRules {get; set;}
    }
    public class AwardVariableMappingItem {
        public string type {get; set;}
        public List<string> variables {get; set;}

        public bool IsScoreVariable {get => type.Equals("score_variable"); set { } }
        public bool IsAwardCheck {get => type.Equals("has_award"); set { } }
    }
    public class DatabaseSettings {
        public List<RankScoreItem> scores {get; set;}
        public List<AwardConfigItem> awards {get; set;}
        public List<AwardVariableMappingItem> award_variable_mapping {get; set;}
        public int GetRankByScore(int score) {
            int last_rank = 0;
            foreach(var item in scores) {
                if(score >= item.minScore && last_rank < item.rank)
                    last_rank = item.rank;
            }

            return last_rank;
        }
    }
    public class ProcessorConfiguration : QueueProcessor.ProcessorConfiguration {
        public DatabaseSettings _databaseSettings {get; set;} //exposed for testing
        public ProcessorConfiguration() {
            _databaseSettings = null;
        }
        public List<AwardConfigItem> GetAwards() {
            return _databaseSettings?.awards;
        }
        public int GetRankByScore(int score) {
            return _databaseSettings.GetRankByScore(score);
        }
        public AwardVariableMappingItem GetVariableMappingItemById(int id) {
            return _databaseSettings.award_variable_mapping[id-1];
        }
        public async Task LoadDatabaseSettings(IMongoCollection<BsonDocument> collection) {
            var aggregateString = "[{$match: {gameid: " + this.gameid.ToString() +", baseKey: \"settings\"}}, {$project: {\"data\":  { $arrayElemAt: [ \"$data\", 0 ] }}}]";
            var aggregateDocument =  BsonSerializer.Deserialize<BsonDocument[]>(aggregateString);

            PipelineDefinition<BsonDocument, BsonDocument> pipeline = aggregateDocument;
            var record = (await collection.AggregateAsync(pipeline)).FirstOrDefault();
            if(record != null && record.Contains("data")) {

                _databaseSettings = new DatabaseSettings();

                var dataRecord = record["data"].AsBsonDocument;

                if(dataRecord.Contains("scores")) {
                    _databaseSettings.scores = GetScoresFromBsonDocument(dataRecord["scores"].AsBsonArray);
                }
                if(dataRecord.Contains("awards")) {
                    _databaseSettings.awards = GetAwardConfigFromBsonDocument(dataRecord["awards"].AsBsonArray);
                }
                if(dataRecord.Contains("award_variable_mapping")) {
                    _databaseSettings.award_variable_mapping = GetAwardMappingFromBsonDocument(dataRecord["award_variable_mapping"].AsBsonArray);
                }
            }
        }
        private List<AwardVariableMappingItem> GetAwardMappingFromBsonDocument(BsonArray award_variable_mapping) {
            var result = new List<AwardVariableMappingItem>();
            foreach(var item in award_variable_mapping) {
                var mappingItem = new AwardVariableMappingItem();
                mappingItem.type = item["type"].AsString;
                mappingItem.variables = new List<string>();
                var variablesArray = item["variables"].AsBsonArray;
                foreach(var variable in variablesArray) {
                    mappingItem.variables.Add(variable.AsString);
                }
                result.Add(mappingItem);
            }
            return result;
        }
        private List<RankScoreItem> GetScoresFromBsonDocument(BsonArray scores) {
            var result = new List<RankScoreItem>();
            foreach(var item in scores) {
                var scoreItem = new RankScoreItem();
                scoreItem.minScore = item["minScore"].AsInt32;
                scoreItem.rank = item["rank"].AsInt32;
                result.Add(scoreItem);
            }
            return result;
        }

        private List<AwardConfigItem> GetAwardConfigFromBsonDocument(BsonArray awards) {
            var result = new List<AwardConfigItem>();
            foreach(var item in awards) {
                var scoreItem = new AwardConfigItem();
                scoreItem.awardKey = item["awardKey"].AsString;
                scoreItem.awardRules = new List<string>();
                var rules = item["rules"].AsBsonArray;
                foreach(var rule in rules) {
                    scoreItem.awardRules.Add(rule.AsString);
                }                
                result.Add(scoreItem);
            }
            return result;
        }
    }
}