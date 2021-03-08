using NUnit.Framework;
using System;
using System.Threading;
using System.Collections.Generic; 
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using Microsoft.Extensions.Logging;
using System.Linq;
using Newtonsoft.Json;
using BF2142.SnapshotProcessor;
using Moq;
namespace bf2142_snapshot_processor.tests
{
    public class Tests
    {
        private Mock<IMongoCollection<BsonDocument>> _collection;
        [SetUp]
        public void Setup()
        {
            _collection = new Mock<IMongoCollection<BsonDocument>>();
        }

        [Test]
        [TestCase("100_1",new string[] {"9,23,ktt-3,54000", "6,1, ,20", "6,168, ,"})]
        [TestCase("100_2",new string[] {"6,1, ,20", "9,23,ktt-3,54000"})]
        [TestCase("100_3",new string[] {"6,1, ,30", "9,23,ktt-3,180000"})]
        [TestCase("101_1",new string[] {"6,2, ,12"})]
        [TestCase("101_2",new string[] {"6,2, ,20", "9,20,ktt-0,54000"})]
        [TestCase("101_3",new string[] {"6,2, ,30", "9,20,ktt-0,180000"})]
        [TestCase("102_1",new string[] {"6,3, ,12"})]
        [TestCase("102_2",new string[] {"6,3, ,20", "9,21,ktt-1,54000"})]
        [TestCase("102_3",new string[] {"6,3, ,30", "9,21,ktt-1,180000"})]
        [TestCase("103_1",new string[] {"6,4, ,12"})]
        [TestCase("103_2",new string[] {"6,4, ,20", "9,22,ktt-2,54000"})]
        [TestCase("103_3",new string[] {"6,4, ,30", "9,22,ktt-2,180000"})]
        [TestCase("104_1",new string[] {"6,50, ,10"})]
        [TestCase("104_2",new string[] {"6,50, ,20", "1,113,slpts,300"})]
        [TestCase("104_3",new string[] {"6,50, ,30", "1,113,slpts,600"})]
        [TestCase("105_1",new string[] {"6,5, ,7"})]
        [TestCase("105_2",new string[] {"6,5, ,10", "1,5,wkls-12,50"})]
        [TestCase("105_3",new string[] {"6,5, ,17", "1,5,wkls-12,150"})]
        [TestCase("106_1",new string[] {"6,7, ,5"})]
        [TestCase("106_2",new string[] {"6,7, ,7", "1,7,wkls-5;wkls-11,50"})]
        [TestCase("106_3",new string[] {"6,7, ,18", "1,7,wkls-5;wkls-11,300"})]
        [TestCase("107_1",new string[] {"6,8, ,10"})]
        [TestCase("107_2",new string[] {"6,8, ,15", "1,8,klse,50"})]
        [TestCase("107_3",new string[] {"6,8, ,20", "1,8,klse,300"})]
        [TestCase("108_1",new string[] {"10,18, ,180"})]
        [TestCase("108_2",new string[] {"6,9, ,15", "9,148,vtp-12;vtp-3;wtp-30,72000"})]
        [TestCase("108_3",new string[] {"6,9, ,30", "9,148,vtp-12;vtp-3;wtp-30,180000"})]
        [TestCase("109_1",new string[] {"6,40, ,30"})]
        [TestCase("109_2",new string[] {"10,150, ,1200", "1,40,csgpm-0,1000"})]
        [TestCase("109_3",new string[] {"10,150, ,1500", "1,40,csgpm-0,4000"})]
        [TestCase("110_1",new string[] {"6,39, ,30"})]
        [TestCase("110_2",new string[] {"10,149, ,1200", "1,39,csgpm-1,1000"})]
        [TestCase("110_3",new string[] {"10,149, ,1500", "1,39,csgpm-1,4000"})]
        [TestCase("111_1",new string[] {"6,42, ,8"})]
        [TestCase("111_2",new string[] {"6,42, ,10", "9,128,etpk-1,36000"})]
        [TestCase("111_3",new string[] {"6,42, ,15", "9,128,etpk-1,216000", "1,42,rps,200"})]
        [TestCase("112_1",new string[] {"6,43, ,8"})]
        [TestCase("112_2",new string[] {"6,43, ,10", "9,129,etpk-5,36000"})]
        [TestCase("112_3",new string[] {"6,43, ,15", "9,129,etpk-5,216000", "1,43,hls,400"})]
        [TestCase("113_1",new string[] {"6,45, ,8"})]
        [TestCase("113_2",new string[] {"6,45, ,10", "9,130,etpk-6,36000"})]
        [TestCase("113_3",new string[] {"6,45, ,15", "9,130,etpk-6,180000", "1,45,resp,400"})]
        [TestCase("114_1",new string[] {"10,141, ,900"})]
        [TestCase("114_2",new string[] {"6,11, ,15", "9,114,atp,90000"})]
        [TestCase("114_3",new string[] {"6,11, ,35", "9,114,atp,180000"})]
        [TestCase("115_1",new string[] {"10,142, ,900"})]
        [TestCase("115_2",new string[] {"6,12, ,15", "9,25,vtp-10;vtp-4,90000"})]
        [TestCase("115_3",new string[] {"6,12, ,35", "9,25,vtp-10;vtp-4,180000"})]
        [TestCase("116_1",new string[] {"10,151, ,600"})]
        [TestCase("116_2",new string[] {"6,116, ,5", "9,115,vtp-1;vtp-4;vtp-6,90000"})]
        [TestCase("116_3",new string[] {"6,116, ,12", "9,115,vtp-1;vtp-4;vtp-6,144000"})]
        [TestCase("117_1",new string[] {"6,46, ,8"})]
        [TestCase("117_2",new string[] {"6,46, ,15", "9,27,tgpm-1,108000"})]
        [TestCase("117_3",new string[] {"6,46, ,30", "9,27,tgpm-1,216000"})]
        [TestCase("118_1",new string[] {"6,47, ,8"})]
        [TestCase("118_2",new string[] {"6,47, ,15", "9,27,tgpm-1,108000"})]
        [TestCase("118_3",new string[] {"6,47, ,30", "9,27,tgpm-1,216000"})]
        [TestCase("119_1",new string[] {"6,48, ,2"})]
        [TestCase("119_2",new string[] {"6,49, ,1", "1,48,tcd,10"})]
        [TestCase("119_3",new string[] {"6,48, ,3", "6,49, ,1", "1,48,tcd,40"})]
        [TestCase("200",new string[] {"6,127, ,"})]
        [TestCase("201",new string[] {"6,126, ,"})]
        [TestCase("202",new string[] {"6,125, ,"})]
        [TestCase("203",new string[] {"6,41, ,30", "9,19,tac,180000", "9,28,tasl,180000", "9,29,tasm,180000"})]
        [TestCase("204",new string[] {"6,59, ,1", "5,62,100_1,1", "5,63,101_1,1", "5,64,102_1,1", "5,65,103_1,1", "5,66,105_1,1", "5,67,106_1,1", "5,68,107_1,1"})]
        [TestCase("205",new string[] {"6,59, ,1", "5,69,100_2,1", "5,70,101_2,1", "5,71,102_2,1", "5,72,103_2,1", "5,73,105_2,1", "5,74,106_2,1", "5,75,107_2,1"})]
        [TestCase("206",new string[] {"6,59, ,1", "5,76,100_3,1", "5,77,101_3,1", "5,78,102_3,1", "5,79,103_3,1", "5,80,105_3,1", "5,81,106_3,1", "5,82,107_3,1"})]
        [TestCase("207",new string[] {"11,30,tt,540000", "3,51,cpt,1000", "3,52,dcpt,400", "3,41,twsc,5000"})]
        [TestCase("208",new string[] {"10,145, ,180", "11,31,attp-0,540000", "1,54,awin-0,300"})]
        [TestCase("209",new string[] {"10,146, ,180", "11,32,attp-1,540000", "1,55,awin-1,300"})]
        [TestCase("210",new string[] {"6,60, ,1", "11,26,tgpm-0,288000", "1,13,kgpm-0,8000", "1,15,bksgpm-0,25"})]
        [TestCase("211",new string[] {"6,61, ,1", "11,27,tgpm-1,288000", "1,14,kgpm-1,8000", "1,16,bksgpm-1,25"})]
        [TestCase("212",new string[] {"6,12, ,30", "9,25,vtp-10;vtp-4,360000", "1,12,vkls-10;vkls-4,8000"})]
        [TestCase("213",new string[] {"6,11, ,25", "9,24,vtp-0;vtp-1;vtp-2,360000", "1,11,vkls-0;vkls-1;vkls-2,8000"})]
        [TestCase("214",new string[] {"6,17, ,27", "6,83, ,0", "9,30,tt,648000"})]
        [TestCase("215",new string[] {"11,30,tt,360000", "3,43,hls,400", "3,42,rps,400", "3,45,resp,400"})]
        [TestCase("216",new string[] {"6,85, ,0.25"})]
        [TestCase("217",new string[] {"6,86, ,10", "9,33,vtp-4,90000"})]
        [TestCase("218",new string[] {"6,14, ,10", "11,27,tgpm-1,540000", "1,133,mbr-1-0;mbr-1-1;mbr-1-2;mbr-1-3;mbr-1-5;mbr-1-10;mbr-1-12,70"})]
        [TestCase("219",new string[] {"6,17, ,20", "1,51,cpt,100", "1,42,rps,70"})]
        [TestCase("300",new string[] {"10,18, ,300", "6,9, ,15"})]
        [TestCase("301",new string[] {"10,142, ,600", "6,12, ,20"})]
        [TestCase("302",new string[] {"6,120, ,10"})]
        [TestCase("303",new string[] {"10,143, ,1200", "9,28,tasl,144000"})]
        [TestCase("304",new string[] {"10,38, ,1200", "6,34, ,40", "9,19,tac,288000"})]
        [TestCase("305",new string[] {"6,41, ,15", "9,29,tasm,36000", "9,28,tasl,36000", "9,19,tac,36000"})]
        [TestCase("306",new string[] {"10,144, ,1080", "6,41, ,40", "9,29,tasm,72000"})]
        [TestCase("307",new string[] {"6,41, ,55", "9,29,tasm,90000", "9,28,tasl,180000"})]
        [TestCase("308",new string[] {"6,34, ,45", "9,19,tac,216000", "5,87,wlr,2"})]
        [TestCase("309",new string[] {"10,141, ,1200", "6,11, ,20"})]
        [TestCase("310",new string[] {"6,110, ,10", "9,121,vtp-0;vtp-1;vtp-2;vtp-6,36000"})]
        [TestCase("311",new string[] {"9,99,mtt-0-0;mtt-1-0,0", "9,101,mtt-0-2;mtt-1-2,0", "9,103,mtt-0-4,0", "9,104,mtt-0-5;mtt-1-5,0", "9,108,mtt-0-9,0", "9,32,attp-1,432000"})]
        [TestCase("312",new string[] {"9,100,mtt-0-1;mtt-1-1,0", "9,102,mtt-0-3;mtt-1-3,0", "9,105,mtt-0-6,0", "9,106,mtt-0-7,0", "9,107,mtt-0-8,0", "9,31,attp-0,432000"})]
        [TestCase("313",new string[] {"6,17, ,20", "1,88,bksgpm-0;bksgpm-1,10"})]
        [TestCase("314",new string[] {"6,17, ,10", "6,83, ,", "11,30,tt,180000"})]
        [TestCase("315",new string[] {"6,17, ,10", "11,30,tt,432000", "1,88,bksgpm-0;bksgpm-1,10"})]
        [TestCase("316",new string[] {"3,10,vkls-7,200"})]
        [TestCase("317",new string[] {"6,86, ,15", "9,33,vtp-4,90000"})]
        [TestCase("318",new string[] {"6,138, ,15", "9,137,vtp-12,36000"})]
        [TestCase("319",new string[] {"6,39, ,10", "11,36,ctgpm-1,90000"})]
        [TestCase("400",new string[] {"6,89, ,5"})]
        [TestCase("401",new string[] {"6,89, ,10"})]
        [TestCase("402",new string[] {"6,48, ,4"})]
        [TestCase("403",new string[] {"6,109, ,4"})]
        [TestCase("404",new string[] {"6,86, ,10"})]
        [TestCase("406",new string[] {"6,47, ,7"})]
        [TestCase("407",new string[] {"6,139, ,5"})]
        [TestCase("408",new string[] {"6,110, ,5"})]
        [TestCase("409",new string[] {"6,93, ,8"})]
        [TestCase("410",new string[] {"6,8, ,8"})]
        [TestCase("411",new string[] {"6,44, ,8"})]
        [TestCase("412",new string[] {"6,124, ,"})]
        [TestCase("413",new string[] {"6,7, ,4"})]
        [TestCase("414",new string[] {"6,9, ,10"})]
        [TestCase("415",new string[] {"6,6, ,10"})]
        [TestCase("120_1",new string[] {"6,152, ,6"})]
        [TestCase("120_2",new string[] {"6,152, ,10", "9,153,mtt-1-10;mtt-2-10;mtt-2-11;mtt-1-12;mtt-2-12,7200"})]
        [TestCase("120_3",new string[] {"6,152, ,14", "9,153,mtt-1-10;mtt-2-10;mtt-2-11;mtt-1-12;mtt-2-12,18000"})]
        [TestCase("121_1",new string[] {"10,154, ,300"})]
        [TestCase("121_2",new string[] {"6,156, ,8", "9,155,vtp-14;vtp-15,3600"})]
        [TestCase("121_3",new string[] {"6,156, ,12", "9,155,vtp-14;vtp-15,14400"})]
        [TestCase("320",new string[] {"6,157, ,5", "5,158,vkls-15,40"})]
        [TestCase("321",new string[] {"6,152, ,15", "5,159,mwin-1-12;mwin-2-12,2", "5,160,mwin-1-10;mwin-2-10,2", "5,161,mwin-2-11,2"})]
        [TestCase("322",new string[] {"6,162, ,9", "9,163,vtp-14,7200"})]
        [TestCase("323",new string[] {"7,164,vdstry-15,4", "7,165,vdstry-14,2", "7,166,vdths-15,5", "7,167,vdths-14,5"})]
        [TestCase("416",new string[] {"6,168, ,"})]
        public void TestAward_ExpectAllVariablesResolvable(string awardName, string[] awardRules) {
            foreach(var rule in awardRules) {
                var splitRules = rule.Split(',');                
                var processorConfig = GetProcessorConfiguration();
                AwardVariableMappingItem mapping = null;
                if(int.TryParse(splitRules[1], out int mappingId)) {
                    mapping = processorConfig.GetVariableMappingItemById(mappingId);
                    if(mapping != null && mapping.IsScoreVariable) {
                        foreach(var variable in mapping.variables) {
                            Assert.IsTrue(TestHasProperty(variable), string.Format("failed to find property {0} in variable mapping for {1}", variable, awardName));
                        }
                    }
                }

                if(!string.IsNullOrWhiteSpace(splitRules[2])) {
                    var ruleVariables = splitRules[2].Split(';');
                    foreach(var variable in ruleVariables) {
                        Assert.IsTrue(TestHasProperty(variable), string.Format("Failed to find property {0} in direct rule reference for {1}", variable, awardName));
                    }
                }
            }
        }
        private bool TestHasProperty(string name) {
            var snapshotType = typeof(BF2142PlayerSnapshot);
            var props = snapshotType.GetProperties();

            var prop = props.Where(g => g.GetCustomAttributes(false).Where(x => x.GetType() == typeof(Newtonsoft.Json.JsonPropertyAttribute) && ((Newtonsoft.Json.JsonPropertyAttribute)x).PropertyName.Equals(name)).FirstOrDefault() != null).FirstOrDefault();
            return prop != null;
        }

        [Test]
        public async Task TestAward_ExpectNoAwards()
        {
            var snapshot = GetEmptySnaphot();
            await BF2142.SnapshotProcessor.AwardsHandler.PerformHandling(snapshot, snapshot, _collection.Object, GetProcessorConfiguration());
            Assert.Pass();
        }

        [Test]
        [TestCase("100_1", new string[] { "9,23,ktt-3,54000", "6,1, ,20", "6,168, ,"})]
        [TestCase("109_2", new string[] { "10,150, ,1200", "1,40,csgpm-0,1000"})]
        [TestCase("204", new string[] { "6,59, ,1", "5,62,100_1,1", "5,63,101_1,1", "5,64,102_1,1", "5,65,103_1,1", "5,66,105_1,1", "5,67,106_1,1", "5,68,107_1,1" })]
        [TestCase("315", new string[] { "6,17, ,10", "11,30,tt,432000", "1,88,bksgpm-0;bksgpm-1,10" })]
        public async Task TestAward_ExpectOnlyAward(string awardName, string[] awardRules)
        {
            var config = GetProcessorConfiguration();

            var testItem = new AwardConfigItem();
            testItem.awardKey = awardName;

            testItem.awardRules = new List<string>();
            testItem.awardRules.AddRange(awardRules);


            config._databaseSettings.awards.Add(testItem);


            var snapshot = GetSnapshotForOnly(awardName);
            await BF2142.SnapshotProcessor.AwardsHandler.PerformHandling(snapshot, snapshot, _collection.Object, config);
            AssertAwardGiven(awardName);
        }

        private bool VerifyAwardInBsonDocument(string awardName, UpdateDefinition<BsonDocument> fd) {
            var doc = fd.ToBsonDocument()["Document"].AsBsonDocument;
            if(doc.Contains("$set")) {
                var setStatement = doc["$set"].AsBsonDocument;
                if(setStatement.Contains("awardName")) {
                    var awardString = setStatement["awardName"].AsString;
                    return awardString.Equals(awardName);
                }
                return true;
            }
            return false;
        }
        private void AssertAwardGiven(string awardName) {
            _collection.Verify(x => x.UpdateOneAsync(It.IsAny<FilterDefinition<BsonDocument>>(), It.Is<UpdateDefinition<BsonDocument>>(fd => VerifyAwardInBsonDocument(awardName, fd)), It.IsAny<UpdateOptions>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        ProcessorConfiguration GetProcessorConfiguration() {
            var result = new ProcessorConfiguration();
            result._databaseSettings = new BF2142.SnapshotProcessor.DatabaseSettings();
            result._databaseSettings.awards = new List<AwardConfigItem>();

            result._databaseSettings.award_variable_mapping = LoadVariableMapping();
            return result;
        }
        List<AwardVariableMappingItem> LoadVariableMapping() {
            var dump = System.IO.File.ReadAllText("/home/dev/code/bf2142_stats/processor/dump.json");
            return (List<AwardVariableMappingItem>)JsonConvert.DeserializeObject(dump, typeof(List<AwardVariableMappingItem>));
        }
        private BF2142PlayerSnapshot GetEmptySnaphot() {
            var snapshot = new BF2142PlayerSnapshot();
            return snapshot;
        }

        private BF2142PlayerSnapshot GetSnapshotForOnly(string awardName) {
            var snapshot = new BF2142PlayerSnapshot();
            switch(awardName) {
                case "100_1":
                    snapshot.time_as_support = 54001;
                    snapshot.kills_as_support = 21;
                break;
                case "109_2":
                    snapshot.ctgpm_zero = 1201;
                    snapshot.csgpm_zero = 1001;
                break;
                case "204":
                break;
                case "315":
                    //"6,17, ,10", "11,30,tt,432000", "1,88,bksgpm-0;bksgpm-1,10"
                    //total kills >= 10
                    //total hours >= 120
                    //best kill streak >= 10 (either team)
                    snapshot.total_kills_pac = 8;
                    snapshot.total_kills_eu = 3;
                    snapshot.time_played = 432001;

                    snapshot.best_kill_streak_eu = 8;
                    snapshot.best_kill_streak_pac = 3;
                break;

            }

            return snapshot;
        }
    }
}