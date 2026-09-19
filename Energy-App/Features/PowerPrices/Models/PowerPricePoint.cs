using System.Text.Json.Serialization;

namespace Energy_App.Features.PowerPrices.Models;

public class PowerPricePoint
{
    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("values")]
    public Dictionary<string, decimal> Values { get; set; } = [];
}
