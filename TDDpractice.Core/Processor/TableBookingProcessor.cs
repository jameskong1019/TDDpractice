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

            var response = Create<TableBookingResponse>(request);

            var availableTables = _tableRepository.GetAvailableTables(request.Date);
            if(availableTables.FirstOrDefault() is Table availableTable)
            {
                var tableBooking = Create<TableBooking>(request);
                tableBooking.TableId = availableTable.Id;
                _tableBookingRepository.Save(tableBooking);

                response.TableBookingId = tableBooking.Id;
                response.ResultCode = TableBookingResultCode.Success;
            }
            else
            {
                response.ResultCode = TableBookingResultCode.NoAvailableTables;
            }

            return response;
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