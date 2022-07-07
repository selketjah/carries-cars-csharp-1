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

        public IVerifiedDuration DurationInMinutes(int minutes)
        {
            return new UnVerifiedDuration(minutes).Verify();
        }
    }

}
