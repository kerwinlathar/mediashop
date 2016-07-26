namespace MediaShopLibary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reinitialretry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        book_id = c.Int(nullable: false),
                        dvd_id = c.Int(nullable: false),
                        book_id1 = c.Int(),
                        customer_id1 = c.Int(),
                        dvd_id1 = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Books", t => t.book_id1)
                .ForeignKey("dbo.Customers", t => t.customer_id1)
                .ForeignKey("dbo.DVDs", t => t.dvd_id1)
                .Index(t => t.book_id1)
                .Index(t => t.customer_id1)
                .Index(t => t.dvd_id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "dvd_id1", "dbo.DVDs");
            DropForeignKey("dbo.Orders", "customer_id1", "dbo.Customers");
            DropForeignKey("dbo.Orders", "book_id1", "dbo.Books");
            DropIndex("dbo.Orders", new[] { "dvd_id1" });
            DropIndex("dbo.Orders", new[] { "customer_id1" });
            DropIndex("dbo.Orders", new[] { "book_id1" });
            DropTable("dbo.Orders");
        }
    }
}
