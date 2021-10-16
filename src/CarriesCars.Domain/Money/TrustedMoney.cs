using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CarriesCars.Domain
{
    public class TrustedMoney : ValueObject, IMoney<TrustedMoney>
    {
        public TrustedMoney(int amount, string currencyIsoCode)
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

        public TrustedMoney MultiplyAndRound(decimal multiplier) => ((IMoney<TrustedMoney>)this).MultiplyAndRound(multiplier);

        TrustedMoney IMoney<TrustedMoney>.MultiplyAndRound(decimal multiplier)
        {
            var multipliedAmount = Amount * multiplier;
            var rounded = Convert.ToInt32(multipliedAmount);
            return new TrustedMoney(rounded, CurrencyIsoCode);
        }
    }


    public static class MoneyExtensions
    {
        public static TrustedMoney EUR(this int amount) => new TrustedMoney(amount, "EUR");

        public static TrustedMoney USD(this int amount) => new TrustedMoney(amount, "USD");

        public static ValueObject ToTrusted(this IMoney<TrustedMoney> money) => money as ValueObject;
    }
}
