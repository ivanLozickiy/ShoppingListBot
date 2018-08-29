using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShoppingListBot.Models.Commands
{
    public class RemoveItemCommand : Command
    {
        public override string Name => @"/removeitem";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            string listName = GetListName(message.Text);
            ShoppingListContext context = new ShoppingListContext();
            ShopList shopList = context.ShopLists.Where(s => s.User.UserTelegramId == message.From.Id).FirstOrDefault(s => s.NameOfList == listName);
            if (shopList == null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "There's no such list.");
                return;
            }
            foreach (string item in GetItems(message.Text))
            {
                BuyItem buyItem = context.BuyItems.Where(b => b.ShopListId == shopList.ShopListId).FirstOrDefault(b => b.Item == item);
                if (buyItem == null)
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "There is no element '" + item + "' in list '" + listName + "'");
                    continue;
                }
                context.BuyItems.Remove(buyItem);
            }
            context.SaveChanges();
            await botClient.SendTextMessageAsync(message.Chat.Id, "Items was succesfully removed");
        }

        string GetListName(string text)
        {
            return text.Replace("/removeitem from", "").Trim().Split(' ')[0];
        }

        string[] GetItems(string text)
        {
            string[] arr = text.Replace("/removeitem from " + GetListName(text), "").Trim().Split(',');
            for (int i = 0; i < arr.Length; i++)
                arr[i] = arr[i].Trim();
            arr = arr.Where(val => val != "").Where(val => val != " ").ToArray();
            return arr;
        }
    }
}