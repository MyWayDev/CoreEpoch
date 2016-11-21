using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;

namespace BaseEpoch.Data.POCO.Promotion
{
   public class ForcastParam
    {
       public int ForcastParamId { get; set; }

       public string ProductId { get; set; }
       public Product Product { get; set; }
       public float GrowthPercentage { get; set; }
       public float PriceIncreasePercentage { get; set; }
       public float PreviousHotPromoPercentage { get; set; }
    }
}
