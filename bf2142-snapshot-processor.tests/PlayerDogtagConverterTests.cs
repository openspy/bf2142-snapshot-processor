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
using BF2142.SnapshotProcessor;
using Moq;
using BF2142SnapshotProcessor.JsonConverters;
using System.Text.Json;
using BF2142SnapshotProcessor.Converters;
namespace bf2142_snapshot_processor.tests
{
    public class PlayerDogtagConverterTests
    {
        [Test]
        [TestCase("{16: 1, 13: 23}", 2)]
        [TestCase("{}", 0)]
        public void Test_DogtagDeserialization(string dottagString, int expectedCount)
        {
            var result = PlayerDogTagsConverter.ParseDogtagsString(dottagString);
            Assert.AreEqual(expectedCount, result.Count);
        }

        [Test]
        [TestCase("lol")]
        [TestCase("")]
        [TestCase(null)]
        public void Test_DogtagDeserialization_BadValues(string dottagString)
        {
            var result = PlayerDogTagsConverter.ParseDogtagsString(dottagString);
            Assert.IsNull(result);
        }
    }
}