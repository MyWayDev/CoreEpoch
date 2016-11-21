using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEpoch.Data.POCO.Base
{
    public class Region
    {
        public virtual IList<ProductPrice> ProductPrices { get; set; }
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public string Currency { get; set; }
       
    }
}
