using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.Data.POCO.Base
{
   public class ProductParam
    {
       public int  ProductParamId { get; set; }
       public string ProductId { get; set; }
       public Product Product { get; set; }
       public string OldId { get; set; }
       public int SeasonId { get; set; }
       public virtual Season Season { get; set; }
       public int NoOfHotMonths { get; set; }
       public bool Clearance { get; set; }
    }
}
