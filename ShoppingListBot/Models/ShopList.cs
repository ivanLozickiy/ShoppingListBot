using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListBot.Models
{
    public class ShopList
    {
        public int ShopListId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public ICollection<string> ShoppingList { get; set; }
        public ShopList()
        {
            ShoppingList = new List<string>();
        }
    }
}