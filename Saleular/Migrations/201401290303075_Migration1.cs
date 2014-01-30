namespace Saleular.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        PhoneID = c.Int(nullable: false, identity: true),
                        Type = c.String(maxLength: 25),
                        Model = c.String(maxLength: 10),
                        Carrier = c.String(maxLength: 10),
                        Capacity = c.String(maxLength: 10),
                        Condition = c.String(maxLength: 10),
                        ImageUrl = c.String(maxLength: 300),
                    })
                .PrimaryKey(t => t.PhoneID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Phone");
        }
    }
}
