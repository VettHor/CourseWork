using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Highway.Models
{
    public class UpdateTable
    {
        public delegate void HighwayListEvent(HighwayList list);
        public static event HighwayListEvent HighWaysFill;
        public void UpDateHighways(HighwayList highWay)
        {
            HighWaysFill?.Invoke(highWay);
        }
    }
}
