using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class SeasonConfig : EntityTypeConfiguration<Season>
    {
        public SeasonConfig()
        {
            Map(m => m.ToTable("Promo.Seasons"));

            HasKey(k => new { k.SeasonId });

            HasMany(p => p.ProductParams)
                .WithRequired(p => p.Season)
                .HasForeignKey(p => p.SeasonId);
        }
    }
}
