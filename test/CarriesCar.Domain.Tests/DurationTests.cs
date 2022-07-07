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
            
        }

        [Fact]
        public void Duration_Of_Zero_Minutes_Throws_Error()
        {
            Action verifyFailing = () => new UnVerifiedDuration(0).Verify();

            Assert.Throws<ArgumentException>(verifyFailing);
        }

        [Fact]
        public void Duration_Of_Minus_Minutes_Throws_Error()
        {
            Action verifyFailing = () => new UnVerifiedDuration(-200).Verify();

            Assert.Throws<ArgumentException>(verifyFailing);
        }
    }

}
