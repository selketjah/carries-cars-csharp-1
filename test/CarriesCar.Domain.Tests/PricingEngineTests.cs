using CarriesCars.Domain;
using CarriesCars.Domain.PricingEngine;
using FluentAssertions;
using System;
using Xunit;

namespace CarriesCar.Domain.Tests
{
    public class PricingEngineTests
    {
        private PricingEngine _pricingEngine;

        public PricingEngineTests()
        {
            _pricingEngine = new PricingEngine();
        }

        [Fact]
        public void Calculates_Price_Per_Minute()
        {
            var pricePerMinute = 30.EUR();
            var duration = UnVerifiedDuration.OfMinutes(1).Verify();

            var calculatedPrice = _pricingEngine.CalculatePrice(pricePerMinute, duration);

            30.EUR().Should().Be(calculatedPrice.ToTrusted());
        }
    }

}
