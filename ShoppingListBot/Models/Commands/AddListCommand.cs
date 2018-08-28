using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShoppingListBot.Models.Commands
{
    public class AddListCommand : Command
    {
        public override string Name => @"/addlist";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            string nameOfList = message.Text.Replace(@"/addlist", "").Trim();
            ShoppingListContext context = new ShoppingListContext();
            ShopList shopList = context.ShopLists.FirstOrDefault(s => s.NameOfList == nameOfList);
            if (shopList != null)
            {
                await botClient.SendTextMessageAsync(chatId, "List with that name already exist, choose another name.");
                return;
            }
            User user = context.Users.FirstOrDefault(u => u.UserTelegramId == message.From.Id);
            shopList = new ShopList { NameOfList = nameOfList, User = user , UserId = user.UserId};
            context.ShopLists.Add(shopList);
            context.SaveChanges();
            WebApiApplication.current_list = nameOfList;            
            await botClient.SendTextMessageAsync(chatId, "Shopping list with name '" + nameOfList + "' was created."); 
        }
    }
}