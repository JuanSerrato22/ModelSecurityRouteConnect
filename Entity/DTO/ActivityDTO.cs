using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Entity.DTO
{
    public class ActivityDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal Price { get; set; }

        [JsonConverter(typeof(TimeSpanHHmmConverter))]
        public TimeSpan DurationHours { get; set; }
    }

    // Conversor personalizado para usar formato "HH:mm"
    public class TimeSpanHHmmConverter : JsonConverter<TimeSpan>
    {
        private const string Format = @"hh\:mm"; // formato HH:mm

        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return TimeSpan.ParseExact(value!, Format, null);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }


}