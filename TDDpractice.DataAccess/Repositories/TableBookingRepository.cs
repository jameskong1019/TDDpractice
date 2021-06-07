using TDDpractice.Core.DataInterface;
using TDDpractice.Core.Domain;

namespace TDDpractice.DataAccess.Repositories
{
    public class TableBookingRepository : ITableBookingRepository
    {
        public TableBookerContext _context { get; }

        public TableBookingRepository(TableBookerContext context)
        {
            _context = context;
        }


        public void Save(TableBooking tableBooking)
        {
            _context.Add(tableBooking);
            _context.SaveChanges();
        }
    }
}