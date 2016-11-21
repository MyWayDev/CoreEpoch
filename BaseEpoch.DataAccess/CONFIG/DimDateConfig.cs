using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO;
using BaseEpoch.Data.POCO.TimeLine;


namespace BaseEpoch.DataAccess.CONFIG
{
    public class DimDateConfig : EntityTypeConfiguration<DimDate>
    {


        public DimDateConfig()
        {

            Map(p => p.ToTable("Warehouse.DimDates"));


           //MapToStoredProcedures(s => s.Insert(i => i.HasName("Warehouse.FillDimDate")));
            

           // HasKey(p => new{p.DateKey,p.Year,p.Month,p.DayOfMonth,p.WeekOfMonth});

            HasKey(p => p.DateKey);

            Property(p => p.DateKey).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();

           

        }
    }
}