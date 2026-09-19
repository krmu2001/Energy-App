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

    public List<PowerPricePoint> FindNegativePricePoints(PowerPriceResponse powerPriceResponse)
    {
        var negativePrices = powerPriceResponse.Data
            .Where(datapoint => datapoint.Values["day_ahead_price"] < 0)
            .ToList();

        return negativePrices;
    }

    public TimeSpan CalculateNegativePriceDuration(PowerPriceResponse powerPriceResponse)
    {
        var negativePricePoints = FindNegativePricePoints(powerPriceResponse).Count;

        var minutes = negativePricePoints * powerPriceResponse.IntervalMinutes;

        return TimeSpan.FromMinutes(minutes);
    }

    public CheapestPeriodResult? FindCheapestPeriod(PowerPriceResponse powerPriceResponse, int durationHours)
    {
        var durationMinutes = durationHours * 60;

        var windowSize =
            durationMinutes / powerPriceResponse.IntervalMinutes;
        
        if (powerPriceResponse.Data.Count < windowSize)
            return null;
        
        CheapestPeriodResult? cheapestPeriod = null;

        var lastEligibleStart =
            powerPriceResponse.Data.Count - windowSize;

        for (var i = 0; i <= lastEligibleStart; i++)
        {
            var window = powerPriceResponse.Data
                .Skip(i)
                .Take(windowSize)
                .ToList();

            var windowIsContinuous = true;
            
            for (var j = 1; j < window.Count; j++)
            {
                var previous = window[j - 1];
                var current = window[j];

                var difference = current.Timestamp - previous.Timestamp;

                if (difference != TimeSpan.FromMinutes(powerPriceResponse.IntervalMinutes))
                {
                    windowIsContinuous = false;
                    break;
                }
            }
            
            if (!windowIsContinuous)
                continue;

            var averagePrice = window
                .Average(pricePoint =>
                    pricePoint.Values["day_ahead_price"]);

            if (cheapestPeriod is null ||
                averagePrice < cheapestPeriod.AveragePrice)
            {
                var start = window.First().Timestamp;
                var end = start.AddMinutes(durationMinutes);

                cheapestPeriod = new CheapestPeriodResult
                {
                    StartDate = start,
                    EndDate = end,
                    AveragePrice = averagePrice
                };
            }
        }

        return cheapestPeriod;
    }
}