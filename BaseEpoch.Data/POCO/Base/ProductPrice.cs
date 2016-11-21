using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.Data.POCO.Base
{
    public class ProductPrice
    {

        public string ProductId  { get; set; }
        public virtual Product Product { get; set; }
        public virtual Promo Promo { get; set; }
        public virtual PromoProduct PromoProduct { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public int PriceId { get; set; }
        public float Price { get; set; }
        public short Bp { get; set; }
        public float Bv { get; set; }
        public PType PriceType { get; set; }
        
    }

    public enum PType
    {
        CatPrice=0,
        CatDiscountPrice=1,
        BasePrice=2,
        DiscountPrice=3,
        PromoPrice=4,
        Free=5,
        
    }
}
