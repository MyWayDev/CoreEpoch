using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO;
using BaseEpoch.Data.POCO.Base;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class ProductConfig : EntityTypeConfiguration<Product>
    {
        
        public ProductConfig()
        {
            Map(p => p.ToTable("Product.Products"));
            
            HasKey(p => p.Id);

            HasRequired(g => g.ProductGroup)
                .WithMany(p => p.Products)
                .HasForeignKey(g => g.GroupId);

            HasMany(m => m.ProductPrices)
                .WithRequired(p => p.Product)
                .HasForeignKey(k => k.ProductId);


            HasMany(p => p.Promos)
                .WithOptional(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .WillCascadeOnDelete(true);

            HasMany(s => s.SalesHistories)
                .WithRequired(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.PromoProducts)
                .WithOptional(p => p.Product)
                .HasForeignKey(p => p.GiftId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.ProductParams)
              .WithRequired(p=>p.Product)
              .HasForeignKey(p => p.ProductId)
              .WillCascadeOnDelete(true);

            HasMany(m => m.ForcastParams)
               .WithRequired(p => p.Product)
               .HasForeignKey(k => k.ProductId);
        
            Property(p => p.Id).HasMaxLength(10).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(p => p.ProductName).IsRequired().HasMaxLength(100);
           
           
            Property(p => p.Active).IsRequired();
            Property(p => p.AddDate).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            Property(p => p.ProductType).IsRequired();
           
            
            //Property(p => p.Active).HasDatabaseGeneratedOption(databaseGeneratedOption:);











        }
    }
}
