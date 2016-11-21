using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.Data.POCO.Promotion
{
    public class Period
    {

        //public int PromoId { get; set; }
        public virtual IList<Season> Seasons { get; set; } 
        public virtual IList<Promo> Promos { get; set; }
        public virtual IList<PeriodDetail> PeriodDetails { get; set; }

        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public PeriodFlg PeriodFlag  { get; set; }
        public bool Active { get; set; }
        public enum PeriodFlg
        {
            Period = 0,
            Season = 1
            
        }
    }
}
