using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DecimalCommaConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();
        if (value != null)
        {
            // Replace the comma with a dot and convert to decimal
            value = value.Replace(",", ".");
            return decimal.Parse(value);
        }
        return 0m;
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}