using CarriesCars.Domain;
using CarriesCars.Domain.PricingEngine;
using FluentAssertions;
using System;
using Xunit;

namespace CarriesCar.Domain.Tests
{
    public class PriceTests
    {
        private PricingEngine _pricingEngine;

        public PriceTests()
        {
        }

        [Fact]
        public void RatePerMinute_of_30_EUR_For_A_1_Minute_Trip_Should_Be_30_EUR()
        {
            var ratePerMinute = 30.EUR();
            var duration = UnVerifiedDuration.OfMinutes(1).Verify();

            var price = new Price(ratePerMinute, duration);

            var total = price.Calculate();

            30.EUR().Should().Be(total.ToTrusted());
        }
    }

}
