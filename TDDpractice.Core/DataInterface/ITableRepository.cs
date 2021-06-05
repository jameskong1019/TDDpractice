using System;
using System.Collections.Generic;
using TDDpractice.Core.Domain;

namespace TDDpractice.Core.DataInterface
{
    public interface ITableRepository
    {
        IEnumerable<Table> GetAvailableTables(DateTime date);
    }
}
