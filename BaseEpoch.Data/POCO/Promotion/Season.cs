using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;

namespace BaseEpoch.Data.POCO.Promotion
{
   public class Season
    {
       public int SeasonId { get; set; }
       public string SeasonName { get; set; }

       public int PeriodId { get; set; }
       public virtual Period Period { get; set; }

       public virtual IList<ProductParam> ProductParams { get; set; }
    }
}
