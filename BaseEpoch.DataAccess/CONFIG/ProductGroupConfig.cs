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
    public class ProductGroupConfig : EntityTypeConfiguration<ProductGroup>
    {
        public ProductGroupConfig()
        {
            Map(p => p.ToTable("Product.ProductGroups"));

           MapToStoredProcedures(s => s.Insert(i => i.HasName("Product.AddGroup")));
            
            HasKey(k => k.GroupId);
            
            HasMany(s => s.SalesHistories)
                .WithRequired(p => p.ProductGroup)
                .HasForeignKey(p => p.GroupId);
           
            HasMany(t => t.ProductTrees)
                .WithRequired(g => g.ProductGroup)
                .HasForeignKey(p => p.GroupId);

            Property(p => p.GroupId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.GroupName).HasMaxLength(55);

        }
    }
}
