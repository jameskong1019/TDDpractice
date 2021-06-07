using System;
using Xunit;

namespace TDDpractice.Core.Validation
{
    public class DateInFutureAttributeTests
    {
        private DateTime dateTimeNow;

        public DateInFutureAttributeTests()
        {
            dateTimeNow = new DateTime(2021, 01, 01);
        }

        [Theory]
        [InlineData(false, -1)]
        [InlineData(false, 0)]
        [InlineData(true, 1)]
        public void ShouldDateInTheFuture(bool expectedResult, int secondsToAdd)
        {
            var attribute = new DateInFutureAttribute(() => dateTimeNow);

            var isValid = attribute.IsValid(dateTimeNow.AddSeconds(secondsToAdd));

            Assert.Equal(expectedResult, isValid);
        }

        [Fact]
        public void ShouldReturnFalseWhenItIsNotDate()
        {
            var attribute = new DateInFutureAttribute();

            Assert.Equal("Date should be in the future", attribute.ErrorMessage);
        }
    }
}
