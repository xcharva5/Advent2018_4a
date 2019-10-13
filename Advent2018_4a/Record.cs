using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2018_4a
{
    class Record
    {
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        
        public Record(DateTime ts, string msg)
        {
            Timestamp = ts;
            Message = msg;
        }
    }
}
