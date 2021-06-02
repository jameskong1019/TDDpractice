﻿using Moq;
using System;
using TDDpractice.Core.DataInterface;
using TDDpractice.Core.Domain;
using Xunit;

namespace TDDpractice.Core.Processor
{
    public class ProcessorTest
    {
        private readonly TableBookingRequest _request;
        private readonly Mock<ITableBookingRepository> _mockTableBookingRepository;
        private readonly TableBookingProcessor _processor;

        public ProcessorTest()
        {
            _request = new TableBookingRequest()
            {
                FirstName = "James",
                LastName = "Kong",
                Number = "403-222-1020",
                Date = new DateTime(2020, 01, 31),
            };

            _mockTableBookingRepository = new Mock<ITableBookingRepository>();
            _processor = new TableBookingProcessor(_mockTableBookingRepository.Object);
        }

        [Fact]
        public void ShouldReturnResult()
        {
            TableBookingResponse response = _processor.BookTable(_request);

            Assert.NotNull(response);
            Assert.Equal(_request.FirstName, response.FirstName);
            Assert.Equal(_request.LastName, response.LastName);
            Assert.Equal(_request.Number, response.Number);
            Assert.Equal(_request.Date, response.Date);
        }

        [Fact]
        public void ShouldReturnArgumentNullException()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => _processor.BookTable(null));
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveTableBooking()
        {
            TableBooking savedTableBooking = null;
            
            // arrange
            _mockTableBookingRepository.Setup(x => x.Save(It.IsAny<TableBooking>())).Callback<TableBooking>(tableBooking =>
            {
                savedTableBooking = tableBooking;
            });
            
            // act
            var response = _processor.BookTable(_request);
            _mockTableBookingRepository.Verify(x => x.Save(It.IsAny<TableBooking>()), Times.Once);

            // assert
            Assert.Equal(_request.FirstName, savedTableBooking.FirstName);
            Assert.Equal(_request.LastName, savedTableBooking.LastName);
            Assert.Equal(_request.Number, savedTableBooking.Number);
            Assert.Equal(_request.Date, savedTableBooking.Date);
        }
    }
}
