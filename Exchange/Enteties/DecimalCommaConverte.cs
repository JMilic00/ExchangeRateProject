using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

public class DecimalCommaConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string value = reader.GetString();
        if (value != null)
        {
            if (value.Contains(","))
            {
                value = value.Replace(",", ".");
            }

            return decimal.Parse(value, System.Globalization.CultureInfo.InvariantCulture); 
        }
        return 0m;
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("0.######", CultureInfo.InvariantCulture));  
    }
}