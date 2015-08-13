namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SellPhoneRequest", "BusinessAreaSelection");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SellPhoneRequest", "BusinessAreaSelection", c => c.String());
        }
    }
}
