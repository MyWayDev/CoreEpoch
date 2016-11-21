using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Base;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class ProductParamConfig : EntityTypeConfiguration<ProductParam>
    {
        public ProductParamConfig()
        {
            Map(m => m.ToTable("Product.ProductParams"));

            HasKey(k => new { k.ProductParamId });


          


        }
    }
}
