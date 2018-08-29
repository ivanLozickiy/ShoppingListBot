using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShoppingListBot.Models.Commands
{
    public class RemoveListCommand : Command
    {
        public override string Name => @"/removelist";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            ShoppingListContext context = new ShoppingListContext();
            string listName = message.Text.Replace("/removelist ", "").Trim();
            ShopList list = context.ShopLists.Where(s => s.User.UserTelegramId == message.From.Id).FirstOrDefault(s => s.NameOfList == listName);
            if (list == null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "There's no such list.");
                return;
            }
            context.ShopLists.Remove(list);
            context.SaveChanges();
            await botClient.SendTextMessageAsync(message.Chat.Id, "List was succesfully removed");
        }
    }
}