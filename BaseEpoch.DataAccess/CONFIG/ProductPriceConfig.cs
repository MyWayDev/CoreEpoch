using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class ProductPriceConfig : EntityTypeConfiguration<ProductPrice>
    {
        public ProductPriceConfig()
        {
            Map(m => m.ToTable("Product.ProductPrices"));

            HasKey(k => k.PriceId);

            Property(p => p.Price).IsRequired();
            Property(p => p.Bp).IsRequired();
            Property(p => p.Bv).IsRequired();
            Property(p => p.PriceType).IsRequired();
        }
    }
}
