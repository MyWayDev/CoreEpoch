using BaseEpoch.Data.POCO.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseEpoch.DataAccess.CONFIG
{
    class RegionConfig : EntityTypeConfiguration<Region>
    {
        public RegionConfig()
        {
            Map(m => m.ToTable("Product.Regions"));

            HasKey(p => p.RegionId);



            HasMany(s => s.ProductPrices)
               .WithRequired(p => p.Region)
               .HasForeignKey(f => f.RegionId);

            Property(p => p.RegionName).HasMaxLength(55);
        }
    }
}
