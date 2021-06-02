using System;
using TDDpractice.Core.DataInterface;
using TDDpractice.Core.Domain;

namespace TDDpractice.Core.Processor
{
    public class TableBookingProcessor
    {
        private readonly ITableBookingRepository _tableBookingRepository;

        public TableBookingProcessor(ITableBookingRepository tableBookingRepository)
        {
            _tableBookingRepository = tableBookingRepository;
        }

        public TableBookingResponse BookTable(TableBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _tableBookingRepository.Save(Create<TableBooking>(request));

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