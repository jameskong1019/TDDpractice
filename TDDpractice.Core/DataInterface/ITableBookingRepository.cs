using TDDpractice.Core.Domain;

namespace TDDpractice.Core.DataInterface
{
    public interface ITableBookingRepository
    {
        void Save(TableBooking tableBooking);
    }
}
