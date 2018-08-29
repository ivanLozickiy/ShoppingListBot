using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListBot.Models
{
    public class BuyItem
    {
        public int BuyItemId { get; set; }
        public string Item { get; set; }
        public int ShopListId { get; set; }
        public ShopList ShopList { get; set; }

        public BuyItem() { }
        public BuyItem(string str)
        {
            Item = str;
        }
    }
}