using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.TimeLine;

namespace BaseEpoch.Data.POCO.TimeLine
{
    public class DimDate
    {
     //   public IList<Period> Periods { get; set; } 
        
        public int DateKey { get; set; }
        public DateTime DateAltKey { get; set; }
        public int Year { get; set; }
        public int Quarter { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int DayOfMonth { get; set; }
        public int DayOfWeek { get; set; }
        public string DayName { get; set; }
        public int WeekOfMonth { get; set; }
        
    }
}
