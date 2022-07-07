using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using System.Collections.Generic;

namespace CarriesCars.Domain.PricingEngine
{
    public class Mileage : ValueObject
    {
        public Mileage(decimal mileageInKms)
        {
            MileageInKms = mileageInKms;
        }

        public decimal MileageInKms { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return MileageInKms;
        }
    }
}
