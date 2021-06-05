using System;
using System.Linq;
using TDDpractice.Core.DataInterface;
using TDDpractice.Core.Domain;

namespace TDDpractice.Core.Processor
{
    public class TableBookingProcessor
    {
        private readonly ITableBookingRepository _tableBookingRepository;
        private readonly ITableRepository _tableRepository;

        public TableBookingProcessor(ITableBookingRepository tableBookingRepository, ITableRepository tableRepository)
        {
            _tableBookingRepository = tableBookingRepository;
            _tableRepository = tableRepository;
        }

        public TableBookingResponse BookTable(TableBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var availableTables = _tableRepository.GetAvailableTables(request.Date);
            if(availableTables.FirstOrDefault() is Table availableTable)
            {
                var tableBooking = Create<TableBooking>(request);
                tableBooking.TableId = availableTable.Id;
                _tableBookingRepository.Save(tableBooking);
            }

            return Create<TableBookingResponse>(request);
        }

        private T Create<T>(TableBookingRequest request) where T : TableBookingBase, new()
        {
            return new T()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Number = request.Number,
                Date = request.Date
            };
        }
    }
}