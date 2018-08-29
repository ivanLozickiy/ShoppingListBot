using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShoppingListBot.Models.Commands
{
    public class ShowListsCommand : Command
    {
        public override string Name => @"/showlists";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            ShoppingListContext context = new ShoppingListContext();
            string answer = "";
            foreach(ShopList shopList in context.ShopLists.Where(s => s.User.UserTelegramId == message.From.Id))
            {
                answer += shopList.NameOfList + "\n";
            }
            await botClient.SendTextMessageAsync(message.Chat.Id, answer);
        }
    }
}