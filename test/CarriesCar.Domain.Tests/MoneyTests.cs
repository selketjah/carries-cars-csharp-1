using CarriesCars.Domain;
using System;
using Xunit;

namespace CarriesCar.Domain.Tests
{
    public class MoneyTests

    {
        [Fact]
        public void Detect_Equal_Values()
        {
            Assert.True(99.EUR() == 99.EUR());
            Assert.True(99.EUR().Equals(99.EUR()));
        }

        [Fact]
        public void Detect_Currency_Differences()
        {
            Assert.True(99.EUR() != 99.USD());
            Assert.False(99.EUR().Equals(99.USD()));
        }

        [Fact]
        public void Detect_Amount_Differences()
        {
            Assert.True(1.EUR() != 2.USD());
            Assert.False(1.EUR().Equals(2.USD()));
        }

        [Fact]
        public void Multiplies_Correctly()
        {
            Assert.True(400.EUR() == 200.EUR().MultiplyAndRound(2.0m));
        }

        [Fact]
        public void Rounds_Up_Correctly()
        {
            Assert.True(200.EUR() == 100.EUR().MultiplyAndRound(1.999m));
        }

        [Fact]
        public void Rounds_Down_Correctly()
        {
            Assert.True(199.EUR() == 100.EUR().MultiplyAndRound(1.994m));
        }
    }
}
