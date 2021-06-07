using System;
using Xunit;

namespace TDDpractice.Core.Validation
{
    public class DateInFutureAttributeTests
    {

        [Theory]
        [InlineData(false, -1)]
        [InlineData(false, 0)]
        [InlineData(true, 1)]
        public void ShouldDateInTheFuture(bool expectedResult, int secondsToAdd)
        {
            var dateTimeNow = new DateTime(2021, 01, 01);
            var attribute = new DateInFutureAttribute(() => dateTimeNow);

            var isValid = attribute.IsValid(dateTimeNow.AddSeconds(secondsToAdd));

            Assert.Equal(expectedResult, isValid);
        }
    }
}
