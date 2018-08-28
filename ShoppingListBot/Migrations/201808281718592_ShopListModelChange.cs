namespace ShoppingListBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopListModelChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShopLists", "UserId", "dbo.Users");
            DropIndex("dbo.ShopLists", new[] { "UserId" });
            AlterColumn("dbo.ShopLists", "UserId", c => c.Int());
            CreateIndex("dbo.ShopLists", "UserId");
            AddForeignKey("dbo.ShopLists", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShopLists", "UserId", "dbo.Users");
            DropIndex("dbo.ShopLists", new[] { "UserId" });
            AlterColumn("dbo.ShopLists", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.ShopLists", "UserId");
            AddForeignKey("dbo.ShopLists", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
