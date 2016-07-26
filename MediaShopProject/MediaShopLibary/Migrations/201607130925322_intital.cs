namespace MediaShopLibary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intital : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        book_id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        author = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.book_id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        book_id = c.Int(nullable: false),
                        dvd_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Books", t => t.book_id, cascadeDelete: true)
                .ForeignKey("dbo.DVDs", t => t.dvd_id, cascadeDelete: true)
                .Index(t => t.book_id)
                .Index(t => t.dvd_id);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        dvd_id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        director = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.dvd_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "dvd_id", "dbo.DVDs");
            DropForeignKey("dbo.Customers", "book_id", "dbo.Books");
            DropIndex("dbo.Customers", new[] { "dvd_id" });
            DropIndex("dbo.Customers", new[] { "book_id" });
            DropTable("dbo.DVDs");
            DropTable("dbo.Customers");
            DropTable("dbo.Books");
        }
    }
}
