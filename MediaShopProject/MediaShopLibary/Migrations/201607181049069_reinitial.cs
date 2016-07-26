namespace MediaShopLibary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reinitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        author = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        director = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DVDs");
            DropTable("dbo.Customers");
            DropTable("dbo.Books");
        }
    }
}
