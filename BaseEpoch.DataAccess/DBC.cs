using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using BaseEpoch.Data.POCO;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.Data.POCO.Promotion;
using BaseEpoch.Data.POCO.TimeLine;
using BaseEpoch.DataAccess.CONFIG;
using BaseEpoch.DataAccess.Migrations;

namespace BaseEpoch.DataAccess
{
    public class DBC : DbContext

    {
        public DBC()
            : base("Name=DataConnection")
        {
           Configuration.LazyLoadingEnabled = false;

        }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductTree> ProductTrees { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<Promo> Promos { get; set; }
        public virtual DbSet<PromoProduct> PromoProducts { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
       // public virtual DbSet<DimDate> DimDates { get; set; }
        public virtual DbSet<SalesHistory> SalesHistories { get; set; } 
        public virtual DbSet<PeriodDetail> PeriodDetails { get;set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<ProductParam> ProductParams { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<ForcastParam> ForcastParams { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Configurations.Add(new ProductConfig());
            modelBuilder.Configurations.Add(new ProductGroupConfig());
            modelBuilder.Configurations.Add(new ProductTreeConfig());
            modelBuilder.Configurations.Add(new PromoConfig());     
           // modelBuilder.Configurations.Add(new DimDateConfig());
            modelBuilder.Configurations.Add(new SalesHistoryConfig());
            modelBuilder.Configurations.Add(new ProductPriceConfig());
            modelBuilder.Configurations.Add(new PeriodConfig());
            modelBuilder.Configurations.Add(new PromoProductConfig());
            modelBuilder.Configurations.Add(new RegionConfig());
            modelBuilder.Configurations.Add(new PeriodDetailConfig());
            modelBuilder.Configurations.Add(new ProductParamConfig());
            modelBuilder.Configurations.Add(new SeasonConfig());
            modelBuilder.Configurations.Add(new ForcastParamConfig());
        }
    }
}
