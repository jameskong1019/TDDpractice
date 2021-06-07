using Microsoft.EntityFrameworkCore;
using TDDpractice.Core.Domain;

namespace TDDpractice.DataAccess
{
    public class TableBookerContext : DbContext
    {
        public TableBookerContext(DbContextOptions<TableBookerContext> options) : base(options)
        {
        }

        public DbSet<TableBooking> TableBooking { get; set; }
    }
}