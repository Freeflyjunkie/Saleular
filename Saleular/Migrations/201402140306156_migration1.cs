namespace Saleular.Migrations
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
                        Capacity = c.String(maxLength: 10),
                        Condition = c.String(maxLength: 10),
                        ImageUrl = c.String(maxLength: 500),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.GadgetID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        GadgetID = c.Int(nullable: false),
                        Type = c.String(maxLength: 25),
                        Model = c.String(maxLength: 10),
                        Carrier = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.GadgetID)
                .ForeignKey("dbo.Gadget", t => t.GadgetID)
                .Index(t => t.GadgetID);
            
            CreateTable(
                "dbo.Tablets",
                c => new
                    {
                        GadgetID = c.Int(nullable: false),
                        Type = c.String(maxLength: 25),
                        Model = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.GadgetID)
                .ForeignKey("dbo.Gadget", t => t.GadgetID)
                .Index(t => t.GadgetID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tablets", "GadgetID", "dbo.Gadget");
            DropForeignKey("dbo.Phones", "GadgetID", "dbo.Gadget");
            DropIndex("dbo.Tablets", new[] { "GadgetID" });
            DropIndex("dbo.Phones", new[] { "GadgetID" });
            DropTable("dbo.Tablets");
            DropTable("dbo.Phones");
            DropTable("dbo.Gadget");
        }
    }
}
