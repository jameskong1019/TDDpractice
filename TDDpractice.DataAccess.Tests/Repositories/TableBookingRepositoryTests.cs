using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TDDpractice.Core.Domain;
using Xunit;

namespace TDDpractice.DataAccess.Repositories
{
    public class TableBookingRepositoryTests
    {
        [Fact]
        public void ShouldSaveTableBooking()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TableBookerContext>()
              .UseInMemoryDatabase(databaseName: "ShouldSaveTheDeskBooking")
              .Options;

            var tableBooking = new TableBooking()
            {
                FirstName = "James",
                LastName = "Kong",
                Number = "403-222-1111",
                Date = new DateTime(2021, 06, 10),
                TableId = 1
            };

            using(var context = new TableBookerContext(options))
            {
                var repository = new TableBookingRepository(context);
                repository.Save(tableBooking);

            }

            using (var context = new TableBookerContext(options))
            {

                var tableBookings = context.TableBooking.ToList();
                var storedTableBooking = Assert.Single(tableBookings);

                Assert.Equal(tableBooking.FirstName, storedTableBooking.FirstName);
                Assert.Equal(tableBooking.LastName, storedTableBooking.LastName);
                Assert.Equal(tableBooking.Number, storedTableBooking.Number);
                Assert.Equal(tableBooking.TableId, storedTableBooking.TableId);
                Assert.Equal(tableBooking.Date, storedTableBooking.Date);
            }
        }

    }
}
