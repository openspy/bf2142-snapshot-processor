using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF2142SnapshotProcessor.Converters {
    public static class PlayerDogTagsConverter {
        public static Dictionary<int, int> ParseDogtagsString(string input) {
            if(string.IsNullOrWhiteSpace(input) || input.Length < 2 || input[0] != '{')
                return null;
            if(input[input.Length-1] != '}')
                return null;


            var reducedInput = input.Substring(1, input.Length-2);
            var output = new Dictionary<int, int>();

            if(string.IsNullOrWhiteSpace(reducedInput)) {
                return output;
            }

            var splitInput = reducedInput.Split(',');
            foreach(var item in splitInput) {
                var dtItems = item.Split(':');
                if(dtItems == null || dtItems.Length != 2) continue;
                var target = dtItems[0].Trim();
                var count = dtItems[1].Trim();
                if(int.TryParse(target, out int targetId) && int.TryParse(count, out int tagCount)) {
                    output[targetId] = tagCount;
                } else {
                    continue;
                }
            }

            return output;
        }
    }
}