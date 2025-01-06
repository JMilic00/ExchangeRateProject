using System.Text.Json.Serialization;

public class ApiExchangeRateEntity
{
    [JsonPropertyName("broj_tecajnice")]
    public required string BrojTecajnice { get; set; }

    [JsonPropertyName("datum_primjene")]
    public required DateTime Date { get; set; }

    [JsonPropertyName("drzava")]
    public required string Drzava { get; set; }

    [JsonPropertyName("drzava_iso")]
    public required string DrzavaIso { get; set; }

    [JsonPropertyName("sifra_valute")]
    public required string SifraValute { get; set; }

    [JsonPropertyName("kupovni_tecaj")]
    [JsonConverter(typeof(DecimalCommaConverter))]
    public required decimal BuyRate { get; set; }

    [JsonPropertyName("prodajni_tecaj")]
    [JsonConverter(typeof(DecimalCommaConverter))]
    public required decimal SellRate { get; set; }

    [JsonPropertyName("srednji_tecaj")]
    [JsonConverter(typeof(DecimalCommaConverter))]
    public required decimal MidRate { get; set; }

    [JsonPropertyName("valuta")]
    public required string Currency { get; set; }
}