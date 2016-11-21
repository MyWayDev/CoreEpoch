namespace BaseEpoch.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PeriodFlagEnum : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Promo.Periods", "PeriodFlag", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("Promo.Periods", "PeriodFlag", c => c.String());
        }
    }
}
