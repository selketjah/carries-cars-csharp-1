using CSharpFunctionalExtensions;

namespace CarriesCars.Domain
{
    public interface IMoney<T> where T : ValueObject, IMoney<T>
    {
        int Amount { get; }

        string CurrencyIsoCode { get; }

        T MultiplyAndRound(decimal multiplier);
    }
}
