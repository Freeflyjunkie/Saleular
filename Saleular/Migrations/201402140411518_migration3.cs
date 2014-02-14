namespace Saleular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Phones", "GadgetID", "dbo.Gadget");
            DropForeignKey("dbo.Tablets", "GadgetID", "dbo.Gadget");
            DropIndex("dbo.Phones", new[] { "GadgetID" });
            DropIndex("dbo.Tablets", new[] { "GadgetID" });
            AddColumn("dbo.Gadget", "Carrier", c => c.String());
            AlterColumn("dbo.Gadget", "Capacity", c => c.String());
            DropTable("dbo.Phones");
            DropTable("dbo.Tablets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tablets",
                c => new
                    {
                        GadgetID = c.Int(nullable: false),
                        IsWiFiOnly = c.Boolean(nullable: false),
                        Carrier = c.String(),
                    })
                .PrimaryKey(t => t.GadgetID);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        GadgetID = c.Int(nullable: false),
                        Carrier = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.GadgetID);
            
            AlterColumn("dbo.Gadget", "Capacity", c => c.String(maxLength: 10));
            DropColumn("dbo.Gadget", "Carrier");
            CreateIndex("dbo.Tablets", "GadgetID");
            CreateIndex("dbo.Phones", "GadgetID");
            AddForeignKey("dbo.Tablets", "GadgetID", "dbo.Gadget", "GadgetID");
            AddForeignKey("dbo.Phones", "GadgetID", "dbo.Gadget", "GadgetID");
        }
    }
}
