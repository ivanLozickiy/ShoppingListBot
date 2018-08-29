using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShoppingListBot.Models.Commands
{
    public class AddItemCommand : Command
    {
        public override string Name => @"/additem";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            ShoppingListContext context = new ShoppingListContext();
            string listName = GetListName(message.Text);
            ShopList shopList = context.ShopLists.FirstOrDefault(s => s.NameOfList == listName);
            if (shopList == null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "There's no such list");
                return;
            }
            foreach (string i in GetItems(message.Text))
            {
                if (context.BuyItems.FirstOrDefault(b => b.Item == i) != null)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, i + " already in list.");
                    continue;
                }
                BuyItem item = new BuyItem { Item = i, ShopList = shopList, ShopListId = shopList.ShopListId };
                context.BuyItems.Add(item);
            }
            context.SaveChanges();
            await botClient.SendTextMessageAsync(message.Chat.Id, "Items was succesfully added");
        }

        public string GetListName(string str)
        {
            string listName = str.Replace("/additem to", "").Trim();
            listName = listName.Split(' ')[0];
            return listName;
        }

        public string[] GetItems(string str)
        {
            string[] arr = str.Replace("/additem to " + GetListName(str), "").Split(',');
            for (int i = 0; i < arr.Length; i++)
                arr[i] = arr[i].Trim();
            return arr;
        }
    }
}