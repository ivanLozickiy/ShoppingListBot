namespace ShoppingListBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuyItems",
                c => new
                    {
                        BuyItemId = c.Int(nullable: false, identity: true),
                        Item = c.String(),
                        ShopListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuyItemId)
                .ForeignKey("dbo.ShopLists", t => t.ShopListId, cascadeDelete: true)
                .Index(t => t.ShopListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BuyItems", "ShopListId", "dbo.ShopLists");
            DropIndex("dbo.BuyItems", new[] { "ShopListId" });
            DropTable("dbo.BuyItems");
        }
    }
}
