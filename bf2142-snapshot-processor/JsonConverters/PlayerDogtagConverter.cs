using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF2142SnapshotProcessor.JsonConverters {
    public class PlayerDogtagConverter : JsonConverter<Dictionary<int, int>> {
        public override Dictionary<int, int> Read(ref Utf8JsonReader reader, Type objectType, JsonSerializerOptions options)
        {
            return BF2142SnapshotProcessor.Converters.PlayerDogTagsConverter.ParseDogtagsString(reader.GetString());
            
        }
        public override void Write(Utf8JsonWriter writer, Dictionary<int, int> value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}