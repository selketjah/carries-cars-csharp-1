using CSharpFunctionalExtensions;

namespace CarriesCars.Domain.PricingEngine
{
    public interface IPricingEngine<T> where T : Money
    {
        Money CalculatePrice(Money pricePerMinute, IDuration duration);

        IDuration DurationInMinutes(int minutes);
    }
}
