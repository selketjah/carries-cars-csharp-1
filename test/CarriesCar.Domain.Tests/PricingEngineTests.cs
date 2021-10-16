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
            var duration = _pricingEngine.DurationInMinutes(1);

            var calculatedPrice = _pricingEngine.CalculatePrice(pricePerMinute, duration);

            30.EUR().Should().Be(calculatedPrice.ToTrusted());
        }

        [Fact]
        public void Guards_Against_0_Or_Negative_Duration()
        {
            Action ZeroPricingDurationPassed = () => _pricingEngine.DurationInMinutes(0);

            Assert.Throws<ArgumentException>(ZeroPricingDurationPassed);
        }

        [Fact]
        public void Duration_Verifies_Valid_Input()
        {
            var input = new UnVerifiedDuration(1);
            var expected = input.Verify();

            expected.Should().Be(_pricingEngine.DurationInMinutes(1));
        }

        [Fact]
        public void Duration_Throws_Error_For_Invalid_Input()
        {
            Action verifyFailing = () => new UnVerifiedDuration(0).Verify();

            Assert.Throws<ArgumentException>(verifyFailing);
        }
    }

}
