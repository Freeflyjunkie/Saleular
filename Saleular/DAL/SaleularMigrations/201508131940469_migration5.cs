namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.SellPhoneRequest", "TaxId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SellPhoneRequest", "TaxId", c => c.String());
        }
    }
}
