namespace NetDaemonApps.Extensions.JsonConverters
{
    internal class TimeSpanDaysJsonConverter : JsonConverter<TimeSpan?>
    {
        public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
         => reader.TokenType == JsonTokenType.Null ? default(TimeSpan?) : TimeSpan.FromDays(reader.GetInt32());

        public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                if (options.DefaultIgnoreCondition >= JsonIgnoreCondition.WhenWritingDefault)
                    writer.WriteNullValue();
            }
            else
                writer.WriteNumberValue((int)Math.Round(value.Value.TotalDays, MidpointRounding.AwayFromZero));

        }
    }
}
