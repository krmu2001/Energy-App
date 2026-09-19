using Energy_App.Features.PowerPrices.Models;

namespace Energy_App.Features.PowerPrices.Analytics;

public class PowerPriceAnalytics
{
    public decimal CalculateAveragePrice(PowerPriceResponse powerPriceResponse)
    {
        if (powerPriceResponse.Data.Count == 0)
            return 0;

        var totalPrice = powerPriceResponse.Data
            .Sum(datapoint => datapoint.Values["day_ahead_price"]);

        return totalPrice / powerPriceResponse.Data.Count;
    }

    public PowerPricePoint? FindMinimumPricePoint(PowerPriceResponse powerPriceResponse)
    {
        var minimumPrice = powerPriceResponse.Data
            .OrderBy(datapoint => datapoint.Values["day_ahead_price"])
            .FirstOrDefault();
        
        return minimumPrice;
    }
    
    public PowerPricePoint? FindMaximumPricePoint(PowerPriceResponse powerPriceResponse)
    {
        var maximumPrice = powerPriceResponse.Data
            .OrderByDescending(datapoint => datapoint.Values["day_ahead_price"])
            .FirstOrDefault();
        
        return maximumPrice;
    }
}