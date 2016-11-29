namespace BaseEpoch.DataAccess.Migrations
{
	using System;
	using System.Data.Entity.Migrations;
	
	public partial class Intial : DbMigration
	{
		public override void Up()
		{
			CreateTable(
				"Promo.ForcastParams",
				c => new
					{
						ForcastParamId = c.Int(nullable: false, identity: true),
						ProductId = c.String(nullable: false, maxLength: 10),
						GrowthPercentage = c.Single(nullable: false),
						PriceIncreasePercentage = c.Single(nullable: false),
						PreviousHotPromoPercentage = c.Single(nullable: false),
					})
				.PrimaryKey(t => t.ForcastParamId)
				.ForeignKey("Product.Products", t => t.ProductId, cascadeDelete: true)
				.Index(t => t.ProductId);
			
			CreateTable(
				"Product.Products",
				c => new
					{
						Id = c.String(nullable: false, maxLength: 10),
						GroupId = c.Int(nullable: false),
						ProductName = c.String(nullable: false, maxLength: 100),
						Active = c.Boolean(nullable: false),
						AddDate = c.DateTime(nullable: false),
						Booking = c.Boolean(nullable: false),
						ProductType = c.Int(nullable: false),
						Discontnuied = c.Boolean(nullable: false),
					})
				.PrimaryKey(t => t.Id)
				.ForeignKey("Product.ProductGroups", t => t.GroupId, cascadeDelete: true)
				.Index(t => t.GroupId);
			
			CreateTable(
				"Product.ProductGroups",
				c => new
					{
						GroupId = c.Int(nullable: false, identity: true),
						GroupName = c.String(maxLength: 55),
						Parentid = c.Int(),
					})
				.PrimaryKey(t => t.GroupId);
			
			CreateTable(
				"Product.ProductTrees",
				c => new
					{
						OrgNode = c.HierarchyId(nullable: false),
						GroupId = c.Int(nullable: false),
						//OrgLevel = c.Int(nullable: false),
						ParentId = c.Int(),
					})
				.PrimaryKey(t => t.OrgNode)
				.ForeignKey("Product.ProductGroups", t => t.GroupId, cascadeDelete: true)
				.Index(t => t.GroupId);
			Sql("ALTER TABLE Product.ProductTrees ADD OrgLevel AS (OrgNode.GetLevel())");
			Sql("CREATE UNIQUE INDEX ProductGroupOrgNc1 ON Product.ProductTrees(OrgLevel, OrgNode)");
			
			CreateTable(
				"WareHouse.SalesHistories",
				c => new
					{
						ProductId = c.String(nullable: false, maxLength: 10),
						Month = c.String(nullable: false, maxLength: 128),
						Year = c.Int(nullable: false),
						GroupId = c.Int(nullable: false),
						PromoId = c.Int(nullable: false),
						Units = c.Int(nullable: false),
						Value = c.Int(nullable: false),
						Forecast = c.Int(nullable: false),
						CountOutDays = c.Int(nullable: false),
						Booking = c.Boolean(nullable: false),
						Price = c.Single(nullable: false),
					})
				.PrimaryKey(t => new { t.ProductId, t.Month, t.Year })
				.ForeignKey("Promo.Promos", t => t.PromoId)
				.ForeignKey("Product.ProductGroups", t => t.GroupId, cascadeDelete: true)
				.ForeignKey("Product.Products", t => t.ProductId)
				.Index(t => t.ProductId)
				.Index(t => t.GroupId)
				.Index(t => t.PromoId);
			
			CreateTable(
				"Promo.Promos",
				c => new
					{
						PromoId = c.Int(nullable: false, identity: true),
						ProductId = c.String(maxLength: 10),
						PeriodId = c.Int(nullable: false),
						ProductPriceId = c.Int(nullable: false),
						PromoName = c.String(maxLength: 55),
						Qty = c.Int(nullable: false),
						PromoGrade = c.Int(nullable: false),
						PromoType = c.Int(nullable: false),
						ProductPrice_PriceId = c.Int(),
					})
				.PrimaryKey(t => t.PromoId)
				.ForeignKey("Promo.Periods", t => t.PeriodId, cascadeDelete: true)
				.ForeignKey("Product.ProductPrices", t => t.ProductPrice_PriceId)
				.ForeignKey("Product.Products", t => t.ProductId, cascadeDelete: true)
				.Index(t => t.ProductId)
				.Index(t => t.PeriodId)
				.Index(t => t.ProductPrice_PriceId);
			
			CreateTable(
				"Promo.Periods",
				c => new
					{
						PeriodId = c.Int(nullable: false, identity: true),
						PeriodName = c.String(maxLength: 55),
						StartDate = c.DateTime(nullable: false),
						EndDate = c.DateTime(nullable: false),
						PeriodFlag = c.Int(nullable: false),
						Active = c.Boolean(nullable: false),
					})
				.PrimaryKey(t => t.PeriodId);
			
			CreateTable(
				"Promo.PeriodDetails",
				c => new
					{
						PeriodDetailId = c.Int(nullable: false),
						PeriodId = c.Int(nullable: false),
						Year = c.Int(nullable: false),
						Quarter = c.Int(nullable: false),
						Month = c.Int(nullable: false),
						MonthName = c.String(),
						DayOfMonth = c.Int(nullable: false),
						DayOfWeek = c.Int(nullable: false),
						DayName = c.String(),
						WeekOfMonth = c.Int(nullable: false),
					})
				.PrimaryKey(t => new { t.PeriodDetailId, t.PeriodId })
				.ForeignKey("Promo.Periods", t => t.PeriodId, cascadeDelete: true)
				.Index(t => t.PeriodId);
			
			CreateTable(
				"Promo.Seasons",
				c => new
					{
						SeasonId = c.Int(nullable: false, identity: true),
						SeasonName = c.String(),
						PeriodId = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.SeasonId)
				.ForeignKey("Promo.Periods", t => t.PeriodId, cascadeDelete: true)
				.Index(t => t.PeriodId);
			
			CreateTable(
				"Product.ProductParams",
				c => new
					{
						ProductParamId = c.Int(nullable: false, identity: true),
						ProductId = c.String(nullable: false, maxLength: 10),
						OldId = c.String(),
						SeasonId = c.Int(nullable: false),
						NoOfHotMonths = c.Int(nullable: false),
						Clearance = c.Boolean(nullable: false),
					})
				.PrimaryKey(t => t.ProductParamId)
				.ForeignKey("Promo.Seasons", t => t.SeasonId, cascadeDelete: true)
				.ForeignKey("Product.Products", t => t.ProductId, cascadeDelete: true)
				.Index(t => t.ProductId)
				.Index(t => t.SeasonId);
			
			CreateTable(
				"Product.ProductPrices",
				c => new
					{
						PriceId = c.Int(nullable: false, identity: true),
						ProductId = c.String(nullable: false, maxLength: 10),
						RegionId = c.Int(nullable: false),
						Price = c.Single(nullable: false),
						Bp = c.Short(nullable: false),
						Bv = c.Single(nullable: false),
						PriceType = c.Int(nullable: false),
					})
				.PrimaryKey(t => t.PriceId)
				.ForeignKey("Product.Regions", t => t.RegionId, cascadeDelete: true)
				.ForeignKey("Product.Products", t => t.ProductId, cascadeDelete: true)
				.Index(t => t.ProductId)
				.Index(t => t.RegionId);
			
			CreateTable(
				"Promo.PromoProducts",
				c => new
					{
						PromoProductId = c.Int(nullable: false, identity: true),
						GiftPriceId = c.Int(nullable: false),
						GiftId = c.String(maxLength: 10),
						PromoId = c.Int(nullable: false),
						GiftQty = c.Int(nullable: false),
						ProductPrice_PriceId = c.Int(),
					})
				.PrimaryKey(t => t.PromoProductId)
				.ForeignKey("Product.ProductPrices", t => t.ProductPrice_PriceId)
				.ForeignKey("Promo.Promos", t => t.PromoId, cascadeDelete: true)
				.ForeignKey("Product.Products", t => t.GiftId)
				.Index(t => t.GiftId)
				.Index(t => t.PromoId)
				.Index(t => t.ProductPrice_PriceId);
			
			CreateTable(
				"Product.Regions",
				c => new
					{
						RegionId = c.Int(nullable: false, identity: true),
						RegionName = c.String(maxLength: 55),
						Currency = c.String(),
					})
				.PrimaryKey(t => t.RegionId);
			CreateStoredProcedure(
			   "Product.AddGroup",
			   p => new
			   {
				   grpid = p.Int(),
				   prntid = p.Int()
			   },
			   body:
					@" DECLARE @pOrgNode hierarchyid, @lc hierarchyid 
						   SELECT @pOrgNode = [OrgNode] 
						   FROM [Product].[ProductTrees] 
						   WHERE [GroupId] = @prntid
						   SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
						   BEGIN TRANSACTION
							  SELECT @lc = max([OrgNode]) 
							  FROM [Product].[ProductTrees]
							  WHERE [OrgNode].GetAncestor(1) =@pOrgNode ;
							 INSERT [Product].[ProductTrees] ([OrgNode], [GroupId],[ParentId])
							  VALUES(@pOrgNode.GetDescendant(@lc, NULL), @grpid, @prntid)
						   COMMIT"
		   );


			CreateStoredProcedure(
				"Promo.PeriodDetailSp",
				p => new
				{
					STARTDATE = p.DateTime(),
					ENDDATE = p.DateTime(),
					PId = p.Int()

				},
				body:
					@" 
					   
					   DECLARE @LOOPDATE DATETIME  
					   SET @LOOPDATE = @STARTDATE
					   WHILE @LOOPDATE <= @ENDDATE
					   BEGIN
 
					   INSERT [Promo].[PeriodDetails]([PeriodId], [PeriodDetailId], [Year], [Quarter], [Month],
									[MonthName], [DayOfMonth], [DayOfWeek], [DayName], [WeekOfMonth])
						  VALUES (
						  @PId,
						  CAST(CONVERT(VARCHAR(8),@LOOPDATE,112)AS INT),
						  YEAR(@LOOPDATE),
						  Datepart(qq,@LOOPDATE),
						  Month(@LOOPDATE),
						  datename(mm,@LOOPDATE),
						  Day(@LOOPDATE),
						  datepart(dw,@LOOPDATE),
						  datename(dw,@LOOPDATE),
						  DATEPART(WEEK, @LOOPDATE)  - DATEPART(WEEK, DATEADD(MM, DATEDIFF(MM,0,@LOOPDATE), 0))+ 1 
						  )
						  SET @LOOPDATE = DateAdd(dd,1,@LOOPDATE)
					  END"
			);

			Sql(" create TRIGGER [Promo].[PeriodDetails_UPDATE] ON [Promo].[Periods] AFTER  UPDATE AS DECLARE @ID INT,@START DATETIME,@END DATETIME SELECT @ID =[PeriodId] from deleted SELECT @START=[StartDate],@END=[EndDate] FROM inserted BEGIN DELETE FROM Promo.PeriodDetails WHERE PeriodId=@ID EXEC Promo.PeriodDetailSp @START,@END,@ID END");
			Sql(" create TRIGGER [Promo].[PeriodDetails_INSERT] ON [Promo].[Periods] AFTER  INSERT AS DECLARE @ID INT,@START DATETIME,@END DATETIME SELECT @ID =[PeriodId],@START=[StartDate],@END=[EndDate] from inserted BEGIN EXEC Promo.PeriodDetailSp @START,@END,@ID END");
			Sql(" create TRIGGER [Promo].[PeriodDetails_Delete] ON [Promo].[Periods] AFTER  delete AS  DECLARE @ID INT SELECT @ID =[PeriodId] from deleted BEGIN DELETE  FROM Promo.PeriodDetails WHERE PeriodId=@ID END");
			Sql("CREATE TRIGGER [Product].[ProductTree_INSERT] ON [Product].[ProductGroups] AFTER  INSERT AS DECLARE @ID INT,@ParentId int SELECT @ID =[GroupId],@ParentId=[Parentid] from inserted  BEGIN  EXEC Product.AddGroup @ID,@ParentId END");
			
		}
		
		public override void Down()
		{
			DropStoredProcedure("dbo.PeriodDetail_Delete");
			DropStoredProcedure("dbo.PeriodDetail_Update");
			DropStoredProcedure("Promo.PeriodDetailSp");
			DropStoredProcedure("dbo.ProductGroup_Delete");
			DropStoredProcedure("dbo.ProductGroup_Update");
			DropStoredProcedure("Product.AddGroup");
			DropForeignKey("WareHouse.SalesHistories", "ProductId", "Product.Products");
			DropForeignKey("Promo.Promos", "ProductId", "Product.Products");
			DropForeignKey("Promo.PromoProducts", "GiftId", "Product.Products");
			DropForeignKey("Product.ProductPrices", "ProductId", "Product.Products");
			DropForeignKey("Product.ProductParams", "ProductId", "Product.Products");
			DropForeignKey("Product.Products", "GroupId", "Product.ProductGroups");
			DropForeignKey("WareHouse.SalesHistories", "GroupId", "Product.ProductGroups");
			DropForeignKey("WareHouse.SalesHistories", "PromoId", "Promo.Promos");
			DropForeignKey("Promo.PromoProducts", "PromoId", "Promo.Promos");
			DropForeignKey("Promo.Promos", "ProductPrice_PriceId", "Product.ProductPrices");
			DropForeignKey("Product.ProductPrices", "RegionId", "Product.Regions");
			DropForeignKey("Promo.PromoProducts", "ProductPrice_PriceId", "Product.ProductPrices");
			DropForeignKey("Promo.Seasons", "PeriodId", "Promo.Periods");
			DropForeignKey("Product.ProductParams", "SeasonId", "Promo.Seasons");
			DropForeignKey("Promo.Promos", "PeriodId", "Promo.Periods");
			DropForeignKey("Promo.PeriodDetails", "PeriodId", "Promo.Periods");
			DropForeignKey("Product.ProductTrees", "GroupId", "Product.ProductGroups");
			DropForeignKey("Promo.ForcastParams", "ProductId", "Product.Products");
			DropIndex("Promo.PromoProducts", new[] { "ProductPrice_PriceId" });
			DropIndex("Promo.PromoProducts", new[] { "PromoId" });
			DropIndex("Promo.PromoProducts", new[] { "GiftId" });
			DropIndex("Product.ProductPrices", new[] { "RegionId" });
			DropIndex("Product.ProductPrices", new[] { "ProductId" });
			DropIndex("Product.ProductParams", new[] { "SeasonId" });
			DropIndex("Product.ProductParams", new[] { "ProductId" });
			DropIndex("Promo.Seasons", new[] { "PeriodId" });
			DropIndex("Promo.PeriodDetails", new[] { "PeriodId" });
			DropIndex("Promo.Promos", new[] { "ProductPrice_PriceId" });
			DropIndex("Promo.Promos", new[] { "PeriodId" });
			DropIndex("Promo.Promos", new[] { "ProductId" });
			DropIndex("WareHouse.SalesHistories", new[] { "PromoId" });
			DropIndex("WareHouse.SalesHistories", new[] { "GroupId" });
			DropIndex("WareHouse.SalesHistories", new[] { "ProductId" });
			DropIndex("Product.ProductTrees", new[] { "GroupId" });
			DropIndex("Product.Products", new[] { "GroupId" });
			DropIndex("Promo.ForcastParams", new[] { "ProductId" });
			DropTable("Product.Regions");
			DropTable("Promo.PromoProducts");
			DropTable("Product.ProductPrices");
			DropTable("Product.ProductParams");
			DropTable("Promo.Seasons");
			DropTable("Promo.PeriodDetails");
			DropTable("Promo.Periods");
			DropTable("Promo.Promos");
			DropTable("WareHouse.SalesHistories");
			DropTable("Product.ProductTrees");
			DropTable("Product.ProductGroups");
			DropTable("Product.Products");
			DropTable("Promo.ForcastParams");
		}
	}
}
