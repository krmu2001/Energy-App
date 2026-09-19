using System.Text.Json.Serialization;

namespace Energy_App.Features.PowerPrices.Models;

public class PowerPriceResponse
{
    [JsonPropertyName("schema_version")]
    public string SchemaVersion { get; set; } = string.Empty;
    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; } = string.Empty;
    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;
    [JsonPropertyName("bidding_zone")]
    public string BiddingZone { get; set; } = string.Empty;
    [JsonPropertyName("timezone")]
    public string TimeZone { get; set; } = string.Empty;
    [JsonPropertyName("resolution")]
    public string Resolution { get; set; } = string.Empty;
    [JsonPropertyName("interval_minutes")]
    public int IntervalMinutes { get; set; }
    [JsonPropertyName("unit")]
    public string Unit  { get; set; } = string.Empty;
    [JsonPropertyName("generated_at")]
    public DateTimeOffset GeneratedAt { get; set; }
    [JsonPropertyName("available_from")]
    public DateTimeOffset AvailableFrom { get; set; }
    [JsonPropertyName("available_until")]
    public DateTimeOffset? AvailableUntil { get; set; }

    [JsonPropertyName("data")]
    public List<PowerPricePoint> Data { get; set; } = [];
}