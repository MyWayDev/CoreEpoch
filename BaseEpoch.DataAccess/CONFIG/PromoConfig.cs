using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class PromoConfig : EntityTypeConfiguration<Promo>
    {
        public PromoConfig()
        {

            Map(p => p.ToTable("Promo.Promos"));
            
            HasKey(k => k.PromoId);

            HasOptional(x => x.ProductPrice)
                .WithOptionalDependent(p => p.Promo);
                //.Map(k => k.MapKey("ProductPriceId"));

           


            HasMany(s=>s.SalesHistories)
                .WithRequired(p=>p.Promo)
                .HasForeignKey(p=>p.PromoId)
                .WillCascadeOnDelete(false);

            HasMany(k => k.PromoProducts)
                .WithRequired(o => o.Promo)
                .HasForeignKey(f => f.PromoId)
                .WillCascadeOnDelete(true);

            Property(p => p.PromoName).HasMaxLength(55);
            Property(p => p.PromoGrade).IsRequired();
            Property(p => p.PromoType).IsRequired();
        }
    }
}
