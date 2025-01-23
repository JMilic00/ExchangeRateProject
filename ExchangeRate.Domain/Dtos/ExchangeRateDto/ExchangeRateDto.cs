using ExchangeRate.Domain.Dtos.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExchangeRate.Domain.Dtos.ExchangeRateDto
{
    public class ExchangeRateDto : BaseDto
    {
        public int Id { get; set; }
        [JsonPropertyName("broj_tecajnice")]
        public string BrojTecajnice { get; set; }

        [JsonPropertyName("datum_primjene")]
        public DateTime Date { get; set; }

        [JsonPropertyName("drzava")]
        public string Drzava { get; set; }

        [JsonPropertyName("drzava_iso")]
        public string DrzavaIso { get; set; }

        [JsonPropertyName("sifra_valute")]
        public string SifraValute { get; set; }

        [JsonPropertyName("kupovni_tecaj")]
        [JsonConverter(typeof(DecimalCommaConverter))]
        public decimal BuyRate { get; set; }

        [JsonPropertyName("prodajni_tecaj")]
        [JsonConverter(typeof(DecimalCommaConverter))]
        public decimal SellRate { get; set; }

        [JsonPropertyName("srednji_tecaj")]
        [JsonConverter(typeof(DecimalCommaConverter))]
        public decimal MidRate { get; set; }

        [JsonPropertyName("valuta")]
        public string Currency { get; set; }
    }
}
