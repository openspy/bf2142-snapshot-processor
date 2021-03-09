using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using BF2142.SnapshotProcessor;

namespace BF2142SnapshotProcessor.JsonConverters {
    public class BF2142SnapshotConverter : JsonConverter<BF2142Snapshot> {
        public override BF2142Snapshot Read(ref Utf8JsonReader reader, Type objectType, JsonSerializerOptions options)
        {
            var snapshot = new BF2142Snapshot();

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return snapshot;
                }

                 // Get the key.
                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException();
                }

                string propertyName = reader.GetString();

                readAndAssignProperty(ref reader, options, propertyName, snapshot);
            }

            throw new JsonException();
        }
        private void handlePlayerVehicleKey(ref Utf8JsonReader reader, JsonSerializerOptions options, string propertyName, BF2142PlayerSnapshot snapshot, int vehicleId) { 
            var type = snapshot.GetType();
            var props = type.GetProperties();

            var vehicleProperty = props.Where(g => g.GetCustomAttributes(false).Where(x => x.GetType() == typeof(VehicleAttribute) && ((VehicleAttribute)x).VehicleId == vehicleId).FirstOrDefault() != null).FirstOrDefault();

            var vehicleType = typeof(BF2142Vehicle);

            var vehicleProps = vehicleType.GetProperties();
            var vehicleVariableProperty = vehicleProps.Where(g => g.GetCustomAttributes(false).Where(x => x.GetType() == typeof(JsonPropertyNameAttribute) && ((JsonPropertyNameAttribute)x).Name .Equals(propertyName)).FirstOrDefault() != null).FirstOrDefault();


            var vehicleInstance = vehicleProperty.GetValue(snapshot);
            if(vehicleInstance == null) {
                vehicleInstance = new BF2142Vehicle();
                vehicleProperty.SetValue(snapshot, vehicleInstance);
            }

            var value = ReadProperty(ref reader, options, vehicleVariableProperty.PropertyType);
            vehicleVariableProperty.SetValue(vehicleInstance, value);
        }

        private object ReadProperty(ref Utf8JsonReader reader, JsonSerializerOptions options, Type propertyType) {
            if(!reader.Read()) {
                throw new JsonException();
            }
            if(propertyType == typeof(System.Int32)) {
                return int.Parse(reader.GetString());
            } else if(propertyType == typeof(string)) {
                return reader.GetString();
            } else if(propertyType == typeof(double)) {
                return double.Parse(reader.GetString());
            } else if(propertyType == typeof(float)) {
                return float.Parse(reader.GetString());
            } else if(propertyType == typeof(System.DateTime)) {
                var converter = new BF2142SnapshotProcessor.JsonConverters.DecimalTimeConverter();
                return converter.Read(ref reader, propertyType, options);                
            } else {
                throw new NotImplementedException();
            }
            
        }
        private BF2142PlayerSnapshot GetPlayerSnapshot(BF2142Snapshot snapshot, int player_index) {
            if(snapshot.player_snapshots.ContainsKey(player_index)) {
                return (BF2142PlayerSnapshot)snapshot.player_snapshots[player_index];
            }

            BF2142PlayerSnapshot player_snapshot = new BF2142PlayerSnapshot();

            snapshot.player_snapshots.Add(player_index, player_snapshot);

            return player_snapshot;
        }
        private void handlePlayerKey(ref Utf8JsonReader reader, JsonSerializerOptions options, string propertyName, BF2142Snapshot snapshot, Match propertyMatchInfo) { 
            if(int.TryParse(propertyMatchInfo.Groups.Values.ElementAt(3).Value, out int playerIndex)) {

                var player_snapshot = GetPlayerSnapshot(snapshot, playerIndex);

                var vehicleMatch = Regex.Match(propertyName, @"v(\w+)-(\d+)_(\d+)");
                if(vehicleMatch.Success) {
                    if(int.TryParse(propertyMatchInfo.Groups.Values.ElementAt(2).Value, out int vehicleId)) {
                        var vehiclePropertyName = vehicleMatch.Groups.Values.ElementAt(1).Value;
                        handlePlayerVehicleKey(ref reader, options, vehiclePropertyName, player_snapshot, vehicleId);
                        return;
                    }
                } else {
                    var weaponMatch = Regex.Match(propertyName, @"w(\w+)-(\d+)_(\d+)");
                    if(weaponMatch.Success) {
                        reader.Read(); //skip weapons for now...
                        return;
                    }
                    
                }

                var type = typeof(BF2142PlayerSnapshot);
                var props = type.GetProperties();

                var playerPropertyName = propertyMatchInfo.Groups.Values.ElementAt(1).Value;

                var playerProperty = props.Where(g => g.GetCustomAttributes(false).Where(x => x.GetType() == typeof(JsonPropertyNameAttribute) && ((JsonPropertyNameAttribute)x).Name.Equals(playerPropertyName)).FirstOrDefault() != null || g.Name.Equals(playerPropertyName)).FirstOrDefault();

                if(playerProperty == null)  {
                    throw new JsonException();
                }
                playerProperty.SetValue(player_snapshot, ReadProperty(ref reader, options, playerProperty.PropertyType));
            }
        }
        private void readAndAssignProperty(ref Utf8JsonReader reader, JsonSerializerOptions options, string propertyName, BF2142Snapshot snapshot) {
            var match = Regex.Match(propertyName, @"((\w|-)+)_(\d+)", RegexOptions.IgnoreCase);
            if(match.Success) {
                handlePlayerKey(ref reader, options, propertyName, snapshot, match);
                return;
            }

            var type = snapshot.game_properties.GetType();
            var props = type.GetProperties();

            var prop = props.Where(g => g.GetCustomAttributes(false).Where(x => x.GetType() == typeof(JsonPropertyNameAttribute) && ((JsonPropertyNameAttribute)x).Name.Equals(propertyName)).FirstOrDefault() != null || g.Name.Equals(propertyName)).FirstOrDefault();

            if(prop == null) {
                throw new JsonException();
            }

            var serverVariableValue = ReadProperty(ref reader, options, prop.PropertyType);

            prop.SetValue(snapshot.game_properties, serverVariableValue);
            
        }
        public override void Write(Utf8JsonWriter writer, BF2142Snapshot value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();   
        }
    }
}