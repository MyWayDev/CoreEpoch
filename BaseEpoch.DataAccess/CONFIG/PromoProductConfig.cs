using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class PromoProductConfig :EntityTypeConfiguration<PromoProduct>
    {
        public PromoProductConfig()
        {
            Map(m => m.ToTable("Promo.PromoProducts"));

            HasKey(p => p.PromoProductId);

            HasOptional(x => x.ProductPrice)
                .WithOptionalDependent(p => p.PromoProduct);
            //.Map(k => k.MapKey("ProductPriceId"));
        }
    }
}
