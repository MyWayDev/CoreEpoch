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
    public class PeriodDetailConfig:EntityTypeConfiguration<PeriodDetail>
    {
        public PeriodDetailConfig()
        {
            Map(m => m.ToTable("Promo.PeriodDetails"));

            HasKey(k => new { k.PeriodDetailId, k.PeriodId });
            Property(k => k.PeriodDetailId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            MapToStoredProcedures(s => s.Insert(i => i.HasName("Promo.PeriodDetailSp")));
        }
    }
}
