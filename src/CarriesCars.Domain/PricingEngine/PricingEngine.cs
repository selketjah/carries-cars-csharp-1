using Ardalis.GuardClauses;
using System;

namespace CarriesCars.Domain.PricingEngine
{
    public class PricingEngine : IPricingEngine<Money>
    {
        public Money CalculatePrice(Money pricePerMinute, IVerifiedDuration duration)
        {
            decimal durationInMinutes = duration.DurationInMinutes;
            return pricePerMinute.MultiplyAndRound(durationInMinutes);
        }

        public Money CalculatePrice(Money pricingRatePerMinute, IVerifiedDuration duration, Money reservationRatePerMinute, IVerifiedDuration reservationDuration) {
            // I have "Money", but by adding reservation costs, I may a new concept => Rate Per Minute
            
            var drivePrice = CalculatePrice(pricingRatePerMinute, duration);
            var reservationPrice = CalculatePrice(reservationRatePerMinute, reservationDuration);

            return drivePrice.Add(reservationPrice);
        }
    }

}
