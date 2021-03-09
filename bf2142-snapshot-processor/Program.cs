using System;
using System.Collections.Generic;
using QueueProcessor;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;

namespace BF2142.SnapshotProcessor
{
    class Program
    {
        private static Dictionary<string, string> getConfigDictionary(string[] args) {
            var dict = new Dictionary<string, string>();
            foreach(var item in args) {
                var items = item.Split(":", 2);
                dict[items[0]] = items[1];
            }
            return dict;
        }
        private static void DIHook(IServiceCollection collection) {

        }
        static void Main(string[] args)
        {
            var config = getConfigDictionary(args);
            BF2142.SnapshotProcessor.ProcessorConfiguration processorConfig = new BF2142.SnapshotProcessor.ProcessorConfiguration();
            processorConfig.gameid = int.Parse(config["GameId"]);
            processorConfig.processorDataType = typeof(QueueProcessor.Utils.Snapshot<BF2142Snapshot>);

            QueueProcessor.Init.RunSnapshotProcessor(typeof(BF2142.SnapshotProcessor.SnapshotProcessor), typeof(BF2142.SnapshotProcessor.ProcessorConfiguration), processorConfig, DIHook);
        }
    }
}
