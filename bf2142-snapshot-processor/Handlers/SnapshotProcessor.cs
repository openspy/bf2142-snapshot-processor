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

namespace BF2142.SnapshotProcessor {
    public class SnapshotProcessor : ISnapshotProcessor {
        private readonly BF2142.SnapshotProcessor.ProcessorConfiguration _processorConfig;
        private readonly IMongoDatabase _database;
        private readonly IPersistentStorage _persistentStorage;

        private readonly ILogger<SnapshotProcessor> _logger;
        private readonly PlayerSnapshotHandler _playerSnapshotHandler;
        public SnapshotProcessor(BF2142.SnapshotProcessor.ProcessorConfiguration processorConfig, IMongoDatabase database, IPersistentStorage persistentStorage, ILogger<SnapshotProcessor> logger, ILogger<PlayerSnapshotHandler> snapshotLogger) {
             processorConfig.LoadDatabaseSettings(database.GetCollection<BsonDocument>("leaderboards")).Wait();
             _processorConfig = processorConfig;
             _database = database;
             _persistentStorage = persistentStorage;
             _logger = logger;
             _playerSnapshotHandler = new PlayerSnapshotHandler(_processorConfig, _database, _persistentStorage, snapshotLogger);
        }
        private async Task HandleSnapshot(BF2142Snapshot snapshot) {
            foreach(var player_snapshot in snapshot.player_snapshots) {
                await _playerSnapshotHandler.HandlePlayerSnapshot(snapshot, player_snapshot);
            }
        }
        public async Task ProcessSnapshot(object snapshot_data) {
            Snapshot<BF2142Snapshot> snapshots = (Snapshot<BF2142Snapshot>)snapshot_data;

            IMongoCollection<BsonDocument> collection = _database.GetCollection<BsonDocument>("player_progress");

            using(CancellationTokenSource cancelSignal = new CancellationTokenSource()) {
                try {
                    var tasks = new List<Task>();
                    foreach(var snapshot in snapshots.snapshots) {
                        tasks.Add(HandleSnapshot(snapshot));

                    }
                    Task.WaitAll(tasks.ToArray(), cancelSignal.Token);

                } catch(Exception e) {
                    cancelSignal.Cancel();
                    throw e;
                }
            }

            IMongoCollection<BsonDocument> snapshotCollection = _database.GetCollection<BsonDocument>("snapshots");

            var set = new BsonDocument();
            set["$set"] = new BsonDocument("processed", new BsonBoolean(true));

            var searchRequest = new BsonDocument();
            searchRequest.Add(new BsonElement("_id", new BsonObjectId(new ObjectId(snapshots._id))));

            await snapshotCollection.UpdateOneAsync(searchRequest, set);
        }
    }
}