namespace ShoppingListBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShopListChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShopLists", "NameOfList", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShopLists", "NameOfList");
        }
    }
}
