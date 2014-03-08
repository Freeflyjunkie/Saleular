namespace Saleular.DAL.SaleularMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gadget",
                c => new
                    {
                        GadgetID = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 25),
                        Model = c.String(maxLength: 10),
                        Capacity = c.String(),
                        Carrier = c.String(),
                        Condition = c.String(maxLength: 10),
                        ImageUrl = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.GadgetID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gadget");
        }
    }
}
