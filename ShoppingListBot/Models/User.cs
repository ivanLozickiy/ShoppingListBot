using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingListBot.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int UserTelegramId { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<ShopList> Catalog { get; set; }
        public User() { }
        public User(int id, string name)
        {
            UserTelegramId = id;
            UserName = name;
            Catalog = new List<ShopList>();
        }
    }
}