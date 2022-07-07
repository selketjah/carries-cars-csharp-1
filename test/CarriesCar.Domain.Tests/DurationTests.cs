using CarriesCars.Domain;
using CarriesCars.Domain.PricingEngine;
using FluentAssertions;
using System;
using Xunit;

namespace CarriesCar.Domain.Tests
{
    public class DurationTests
    {
        private PricingEngine _pricingEngine;

        public DurationTests()
        {
            _pricingEngine = new PricingEngine();
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
