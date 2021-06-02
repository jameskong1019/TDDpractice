using System;
using Xunit;

namespace TDDpractice.Core.Processor
{
    public class ProcessorTest
    {
        [Fact]
        public void ShouldReturnResult()
        {
            TableBookingRequest request = new TableBookingRequest()
            {
                FirstName = "James",
                LastName = "Kong",
                Number = "403-222-1020",
                Date = new DateTime(2020,01,31),
            };

            TableBookingProcessor processor = new TableBookingProcessor();

            TableBookingResponse response = processor.BookTable(request);

            Assert.NotNull(response);
            Assert.Equal(request.FirstName, response.FirstName);
            Assert.Equal(request.LastName, response.LastName);
            Assert.Equal(request.Number, response.Number);
            Assert.Equal(request.Date, response.Date);
        }

        [Fact]
        public void ShouldReturnArgumentNullException()
        {
            TableBookingProcessor processor = new TableBookingProcessor();

            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => processor.BookTable(null));

            Assert.Equal("request", exception.ParamName);
        }
    }
}
