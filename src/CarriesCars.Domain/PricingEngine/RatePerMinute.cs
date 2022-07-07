using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CarriesCars.Domain
{
    public class RatePerMinute : ValueObject
    {
        public RatePerMinute(int amount, string currencyIsoCode)
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
    }
}