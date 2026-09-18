using System.Text.Json.Serialization;

namespace Energy_App.Features.EnergyCharts.Models;

public class EnergyPricePoint
{
    [JsonPropertyName("timestamp")]
    public DateTimeOffset Timestamp { get; set; }

    [JsonPropertyName("values")]
    public Dictionary<string, decimal> Values { get; set; } = [];
}
