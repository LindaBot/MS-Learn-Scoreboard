using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_Learn_Scoreboard.Models
{
    public class Debug
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string Exception { get; set; }
    }
}
