using CSharpFunctionalExtensions;

namespace CarriesCars.Domain.PricingEngine
{
    public interface IPricingEngine<T> where T : ValueObject, IMoney<T>
    {
        IMoney<T> CalculatePrice(IMoney<T> pricePerMinute, IDuration duration);

        IDuration DurationInMinutes(int minutes);
    }
}
