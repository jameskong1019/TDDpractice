using System;

namespace TDDpractice.Core.Processor
{
    public class TableBookingProcessor
    {
        public TableBookingProcessor()
        {
        }

        public TableBookingResponse BookTable(TableBookingRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

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