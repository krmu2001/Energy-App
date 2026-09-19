using Energy_App.Features.PowerPrices.Models;

namespace Energy_App.Features.PowerPrices.Services;

public class EnergyChartService : IEnergyChartService
{
    private readonly HttpClient _httpClient;
    
    public EnergyChartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PowerPriceResponse?> GetPricesAsync(string biddingZone, DateOnly start, DateOnly end)
    {
        var url = $"v2/price?bzn={biddingZone}&start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}";
    
        var result = await _httpClient.GetFromJsonAsync<PowerPriceResponse>(url);

        return result;
    }
}