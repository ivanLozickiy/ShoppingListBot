using System.Data.Entity;

namespace ShoppingListBot.Models
{
    public class ShoppingListContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }
        public ShoppingListContext() : base("ShopLists") { }
    }
}