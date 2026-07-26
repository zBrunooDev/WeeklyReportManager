using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyReportManager
{
    internal class ActivityReport
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TaskName { get; set; }
        public int Quantity { get; set; }
        public string Observation { get; set; }

    }
}
