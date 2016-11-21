using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.Data.POCO.TimeLine;

namespace BaseEpoch.Data.POCO.Promotion
{
   public class Promo
    {
       public string ProductId { get; set; }
       public virtual Product Product { get; set; }
       public virtual IList<PromoProduct> PromoProducts { get; set; }
       public int PeriodId { get; set; }       
       public virtual Period Period { get; set; }
       public virtual IList<SalesHistory> SalesHistories { get; set; }
       public int ProductPriceId { get; set; }
       public virtual ProductPrice ProductPrice { get; set; }
       public int PromoId { get; set; }
       public string PromoName { get; set; }

       public int Qty { get; set; }
       public PromoGrade PromoGrade { get; set; }
       
       public PromoType PromoType { get; set; }

    }
   public enum PromoType
   {
       DiscountPrice = 0,
       FreeProduct = 1,
       ListofProducts = 2,
       Set=3
   }
    public enum PromoGrade
    {
        A = 1,
        B = 2,
        C = 3        
    }
}
