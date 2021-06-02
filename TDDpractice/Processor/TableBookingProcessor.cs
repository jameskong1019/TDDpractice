using System;

namespace TDDpractice.Core.Processor
{
    internal class TableBookingProcessor
    {
        public TableBookingProcessor()
        {
        }

        internal TableBookingResponse BookTable(TableBookingRequest request)
        {
            return new TableBookingResponse()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Number = request.Number,
                Date = request.Date
            };
        }
    }
}