namespace CarriesCars.Domain.PricingEngine
{
    public interface IDuration
    {
        int DurationInMinutes { get; }
    }

    public interface IVerifiedDuration : IDuration {
        
    }
}
