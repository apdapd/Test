using Domain;
using System.Collections.Generic;

namespace DB_WorkEntity
{
    public interface IConnection
    {
        List<EndDayShow> GetEndDayShowProcedure(int numend, int kind);
    }
}
