using System;

namespace CarriesCars.Domain.PricingEngine
{
    public class PricingEngine : IPricingEngine<TrustedMoney>
    {
        public IMoney<TrustedMoney> CalculatePrice(IMoney<TrustedMoney> pricePerMinute, IDuration duration)
        {
            if (duration is UnVerifiedDuration) throw new ArgumentException("Duration must be verified");

            decimal durationInMinutes = duration.DurationInMinutes;
            return pricePerMinute.MultiplyAndRound(durationInMinutes);
        }

        public IDuration DurationInMinutes(int minutes)
        {
            return new UnVerifiedDuration(minutes).Verify();
        }
    }

}
