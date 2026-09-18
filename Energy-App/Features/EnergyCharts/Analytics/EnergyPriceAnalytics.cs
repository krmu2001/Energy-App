using Energy_App.Features.EnergyCharts.Models;

namespace Energy_App.Features.EnergyCharts.Analytics;

public class EnergyPriceAnalytics
{
    public decimal CalculateAveragePrice(ElectricityPrice electricityPrice)
    {
        if (electricityPrice.Data.Count == 0)
            return 0;

        var totalPrice = electricityPrice.Data
            .Sum(datapoint => datapoint.Values["day_ahead_price"]);

        return totalPrice / electricityPrice.Data.Count;
    }

    public EnergyPricePoint? FindMinimumPricePoint(ElectricityPrice electricityPrice)
    {
        var minimumPrice = electricityPrice.Data
            .OrderBy(datapoint => datapoint.Values["day_ahead_price"])
            .FirstOrDefault();
        
        return minimumPrice;
    }
    
    public EnergyPricePoint? FindMaximumPricePoint(ElectricityPrice electricityPrice)
    {
        var maximumPrice = electricityPrice.Data
            .OrderByDescending(datapoint => datapoint.Values["day_ahead_price"])
            .FirstOrDefault();
        
        return maximumPrice;
    }
}