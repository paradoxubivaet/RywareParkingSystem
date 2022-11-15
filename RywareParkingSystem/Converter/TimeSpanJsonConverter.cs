using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RywareParkingSystem.Converter
{
    public class TimeSpanJsonConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (var jsonDoc = JsonDocument.ParseValue(ref reader))
            {
                var value = jsonDoc.RootElement.GetString();
                return TimeSpan.Parse(value);
            }
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
