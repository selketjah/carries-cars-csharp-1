using CSharpFunctionalExtensions;

namespace CarriesCars.Domain.PricingEngine
{
    public interface IPricingEngine<T> where T : Money
    {
        Money CalculatePrice(Money pricePerMinute, IVerifiedDuration duration);

        Money CalculatePrice(Money pricingRatePerMinute, IVerifiedDuration duration, Money reservationRatePerMinute, IVerifiedDuration reservationDuration);

        IVerifiedDuration DurationInMinutes(int minutes);
    }
}
