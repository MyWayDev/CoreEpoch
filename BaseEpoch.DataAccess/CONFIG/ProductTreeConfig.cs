﻿using System;
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
    public class ProductTreeConfig : EntityTypeConfiguration<ProductTree>
    {
        public ProductTreeConfig()
        {
            Map(p => p.ToTable("Product.ProductTrees"));
            HasKey(k => k.OrgNode);
           
            Property(p => p.OrgLevel)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
            
            Property(p=>p.ParentId).IsOptional();
            //MapToStoredProcedures(s => s.Insert(i => i.HasName("AddGroup")));
        }

    }
}
