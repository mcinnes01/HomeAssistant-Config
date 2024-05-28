using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NetDaemon.Extensions.JsonConverters
{
    internal class TimeSpanSecondsJsonConverter : JsonConverter<TimeSpan?>
    {
        public override TimeSpan? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
         => reader.TokenType == JsonTokenType.Null ? default(TimeSpan?) : TimeSpan.FromSeconds(reader.GetInt32());

        public override void Write(Utf8JsonWriter writer, TimeSpan? value, JsonSerializerOptions options)
        {
            if (value == null)
            {
                if (options.DefaultIgnoreCondition >= JsonIgnoreCondition.WhenWritingDefault)
                    writer.WriteNullValue();
            }
            else
                writer.WriteNumberValue((int)Math.Round(value.Value.TotalSeconds, MidpointRounding.AwayFromZero));

        }
    }
}
