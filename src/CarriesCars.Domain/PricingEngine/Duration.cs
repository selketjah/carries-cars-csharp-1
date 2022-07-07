using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace CarriesCars.Domain.PricingEngine
{
    public class UnVerifiedDuration : ValueObject, IDuration
    {
        private record VerifiedDuration(int durationInMinutes) : IVerifiedDuration
        {
            public int DurationInMinutes => durationInMinutes;
        }

        private readonly int durationInMinutes;

        public UnVerifiedDuration(int durationInMinutes)
        {
            this.durationInMinutes = durationInMinutes;
        }

        public int DurationInMinutes => durationInMinutes;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return durationInMinutes;
        }

        public IVerifiedDuration Verify()
        {
            Guard.Against.NegativeOrZero(durationInMinutes, nameof(durationInMinutes), "Duration should be a positive number in minutes");

            return new VerifiedDuration(durationInMinutes);
        }

        public static UnVerifiedDuration OfMinutes(int minutes)
        {
            return new UnVerifiedDuration(minutes);
        }
    }
}
