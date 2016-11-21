using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;


namespace BaseEpoch.Data.POCO.Promotion
{
   public class PromoProduct
    {
       public int GiftPriceId { get; set; }
       public virtual ProductPrice ProductPrice { get; set; }
       public string GiftId { get; set; }
       public virtual Product Product { get; set; }
       public int PromoId { get; set; }
       public virtual Promo Promo { get; set; }

       public int PromoProductId { get; set; }
       public int GiftQty { get; set; }
      
    }
}
