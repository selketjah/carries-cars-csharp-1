using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CarriesCars.Domain
{
    public class Money : ValueObject
    {
        public Money(int amount, string currencyIsoCode)
        {
            Amount = amount;
            CurrencyIsoCode = currencyIsoCode;
        }

        public int Amount { get; }

        public string CurrencyIsoCode { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
            yield return CurrencyIsoCode;
        }

        public Money MultiplyAndRound(decimal multiplier)
        {
            var multipliedAmount = Amount * multiplier;
            var rounded = Convert.ToInt32(multipliedAmount);
            return new Money(rounded, CurrencyIsoCode);
        }
    }


    public static class MoneyExtensions
    {
        public static Money EUR(this int amount) => new Money(amount, "EUR");

        public static Money USD(this int amount) => new Money(amount, "USD");

        public static ValueObject ToTrusted(this Money money) => money as ValueObject;
    }
}
