namespace RTLPracticsApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class student1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemPId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Order_OrderOId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemPId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderOId)
                .Index(t => t.Order_OrderOId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderOId = c.Int(nullable: false, identity: true),
                        OrderNo = c.String(),
                    })
                .PrimaryKey(t => t.OrderOId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(),
                        CategoryIds = c.Int(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Items", "Order_OrderOId", "dbo.Orders");
            DropIndex("dbo.SubCategories", new[] { "Category_CategoryId" });
            DropIndex("dbo.Items", new[] { "Order_OrderOId" });
            DropTable("dbo.SubCategories");
            DropTable("dbo.Students");
            DropTable("dbo.Orders");
            DropTable("dbo.Items");
            DropTable("dbo.Departments");
            DropTable("dbo.Categories");
        }
    }
}
