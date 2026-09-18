using Energy_App.Features.EnergyCharts.Models;

namespace Energy_App.Features.EnergyCharts.Services;

public class EnergyChartService
{
    private readonly HttpClient _httpClient;
    
    public EnergyChartService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ElectricityPrice?> GetPricesAsync(string biddingZone, DateOnly start, DateOnly end)
    {
        var url = $"v2/price?bzn={biddingZone}&start={start:yyyy-MM-dd}&end={end:yyyy-MM-dd}";
    
        var result = await _httpClient.GetFromJsonAsync<ElectricityPrice>(url);

        return result;
    }
}