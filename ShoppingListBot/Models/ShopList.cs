using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListBot.Models
{
    public class ShopList
    {
        public int ShopListId { get; set; }
        public int? UserId { get; set; }
        public string NameOfList { get; set; }
        public User User { get; set; }
        public virtual ICollection<BuyItem> ShoppingList { get; set; }
        public ShopList()
        {
            ShoppingList = new List<BuyItem>();
        }
        public ShopList(string name, int idUser)
        {
            UserId = idUser;
            NameOfList = name;
            ShoppingList = new List<BuyItem>();
        }
    }
}