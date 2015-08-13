namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PriceListRequest", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.SellPhoneRequest", "CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SellPhoneRequest", "CreatedDate");
            DropColumn("dbo.PriceListRequest", "CreatedDate");
        }
    }
}
