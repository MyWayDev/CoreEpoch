using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO.Promotion;

namespace BaseEpoch.DataAccess.CONFIG
{
    public class ForcastParamConfig : EntityTypeConfiguration<ForcastParam>
    {
        public ForcastParamConfig()
        {

            Map(p => p.ToTable("Promo.ForcastParams"));

            HasKey(k => k.ForcastParamId);

           
        }
    }
}
