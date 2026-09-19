namespace Energy_App.Features.PowerPrices.Analytics;

public class CheapestPeriodResult
{
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public decimal AveragePrice { get; set; }
}