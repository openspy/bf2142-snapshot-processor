using System;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json.Serialization;
namespace BF2142.SnapshotProcessor {
    public static class AwardsHandler {
        static public async Task PerformHandling(BF2142PlayerSnapshot gameserverSnapshot, BF2142PlayerSnapshot playerInfoSnapshot, IMongoCollection<BsonDocument> collection, BF2142.SnapshotProcessor.ProcessorConfiguration processorConfig) {
            var awards = processorConfig.GetAwards();
            foreach(var award in awards) {
                if(TestAward(award, gameserverSnapshot, playerInfoSnapshot, processorConfig)) {
                    await AwardAward(award, playerInfoSnapshot.profileid, collection);
                }
            }
        }
        static bool TestAward(AwardConfigItem award, BF2142PlayerSnapshot gameserverSnapshot, BF2142PlayerSnapshot playerInfoSnapshot, BF2142.SnapshotProcessor.ProcessorConfiguration processorConfig) {
            foreach(var rule in award.awardRules) {
                if(!TestSnapshotForRule(rule, gameserverSnapshot, playerInfoSnapshot, processorConfig)) {
                    return false;
                }
            }
            return true;
        }
        static bool TestSnapshotForRule(string ruleString, BF2142PlayerSnapshot gameserverSnapshot, BF2142PlayerSnapshot playerInfoSnapshot, BF2142.SnapshotProcessor.ProcessorConfiguration processorConfig) {
            var splitRules = ruleString.Split(',');
            if(splitRules == null || splitRules.Length != 4) return false;

            bool allow_award_stacking = false;

            float required_accumulator = 0.0f;
            if(!float.TryParse(splitRules[3].Trim(), out required_accumulator)) {
                return true; //the game seems to skip these
            }

            AwardVariableMappingItem mapping = null;
            if(int.TryParse(splitRules[1], out int mappingId)) {
                mapping = processorConfig.GetVariableMappingItemById(mappingId);
                if(mapping == null) {
                    return false;
                }
            } else {
                return false;
            }


            BF2142PlayerSnapshot snapshot = playerInfoSnapshot;

            if(int.TryParse(splitRules[0], out int ruleType)) {
                switch(ruleType) {
                    case 1: //all time
                    case 9: //hours
                    case 10: //minutes
                    case 11: //hours
                    case 5: //? -- uses variables
                    case 7: //? -- uses variables
                    
                    break;
                    case 6: //in a round
                    allow_award_stacking = true;
                    snapshot = gameserverSnapshot;
                    break;
                    default:
                        throw new NotImplementedException();
                }
            }

            if(mapping.IsScoreVariable) {
                float accum = GetAwardAccumulatedValue(snapshot, mapping);
                if(accum >= required_accumulator) {
                    return true;
                }
            } else if (mapping.IsAwardCheck) {
                return true; //xxx: code this!
            }
            return false;
        }
        static float GetAwardAccumulatedValue(BF2142PlayerSnapshot snapshot, AwardVariableMappingItem mapping) {
            float v = 0.0f;
            var type = snapshot.GetType();
            var props = type.GetProperties();
            foreach(var variable in mapping.variables) {
                var prop = props.Where(g => g.GetCustomAttributes(false).Where(x => x.GetType() == typeof(JsonPropertyNameAttribute)
                
                && ((JsonPropertyNameAttribute)x).Name.Equals(variable)

                ).FirstOrDefault() != null).FirstOrDefault();

                if(prop != null) {
                    var propValue = prop.GetValue(snapshot);
                    if(float.TryParse(propValue.ToString(), out float floatValue)) {
                        v += floatValue;
                    }
                }
            }
            return v;
        }
        static async Task AwardAward(AwardConfigItem award, int profileid, IMongoCollection<BsonDocument> collection) {

            var set = new BsonDocument();
            set["$set"] = new BsonDocument("awardName", new BsonString(award.awardKey));

            var searchRequest = new BsonDocument();
            //searchRequest.Add(new BsonElement("_id", new BsonObjectId(new ObjectId(snapshots._id))));

            await collection.UpdateOneAsync(searchRequest, set);
            //throw new NotImplementedException();
        }
    }
}