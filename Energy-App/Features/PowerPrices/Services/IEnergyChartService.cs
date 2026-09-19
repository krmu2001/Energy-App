using Energy_App.Features.PowerPrices.Models;

namespace Energy_App.Features.PowerPrices.Services;

public interface IEnergyChartService
{ 
    Task<PowerPriceResponse?> GetPricesAsync(string biddingZone, DateOnly start, DateOnly end);
}