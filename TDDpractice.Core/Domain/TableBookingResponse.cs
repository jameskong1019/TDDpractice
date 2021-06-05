namespace TDDpractice.Core.Domain
{
    public class TableBookingResponse : TableBookingBase
    {
        public TableBookingResultCode ResultCode { get; set; }
        public int? TableBookingId { get; set; }
    }
}