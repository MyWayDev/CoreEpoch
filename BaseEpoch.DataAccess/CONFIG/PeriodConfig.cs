using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class PeriodConfig : EntityTypeConfiguration<Period>
    {
        public PeriodConfig()
        {
            Map(m => m.ToTable("Promo.Periods"));

            HasKey(p => p.PeriodId);

            HasMany(m => m.PeriodDetails)
                .WithRequired(p => p.Period)
                .HasForeignKey(k => k.PeriodId);

            HasMany(s => s.Promos)
               .WithRequired(p => p.Period)
               .HasForeignKey(f => f.PeriodId);

            HasMany(m => m.Seasons)
              .WithRequired(p => p.Period)
              .HasForeignKey(k => k.PeriodId);

            Property(p => p.PeriodName).HasMaxLength(55);
        }
    }
}
