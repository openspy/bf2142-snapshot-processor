using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF2142SnapshotProcessor.JsonConverters {
    public class DecimalTimeConverter : JsonConverter<System.DateTime> {
        public override System.DateTime Read(ref Utf8JsonReader reader, Type objectType, JsonSerializerOptions options)
        {

            if(double.TryParse(reader.GetString(), out double result)) {
                double ms = result * 1000;
                var date = System.DateTime.UnixEpoch;
                date = date.AddMilliseconds(ms);
                return date;
            }
            return DateTime.MinValue;
            
        }
        public override void Write(Utf8JsonWriter writer, System.DateTime value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}