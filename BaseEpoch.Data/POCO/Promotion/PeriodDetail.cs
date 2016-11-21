using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.Data.POCO.Promotion
{
    public class PeriodDetail
    {
        public int PeriodId { get; set; }
        public Period Period { get; set; }

        public int PeriodDetailId { get; set; }
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
