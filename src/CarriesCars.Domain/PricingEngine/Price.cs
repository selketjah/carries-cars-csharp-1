using Ardalis.GuardClauses;
using CarriesCars.Domain.PricingEngine;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace CarriesCars.Domain
{
    public class Price : ValueObject
    {
        public Price(Money ratePerMinute, IVerifiedDuration duration)
        {
            RatePerMinute = ratePerMinute;
            Duration = duration;
        }

        public Money RatePerMinute { get; }

        public IVerifiedDuration Duration { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return RatePerMinute;
            yield return Duration;
        }

        public Money Calculate()
        {
            decimal durationInMinutes = this.Duration.DurationInMinutes;
            return this.RatePerMinute.MultiplyAndRound(durationInMinutes);
        }
    }
}
