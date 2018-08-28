using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Data.Entity;


namespace ShoppingListBot.Models.Commands
{
    public class StartCommand : Command
    {

        public override string Name => @"/start";

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            ShoppingListContext context = new ShoppingListContext();
            //User user;
            User user = await context.Users.FirstOrDefaultAsync(u => u.UserTelegramId == message.From.Id);
            if (user == null)
            {
                user = new User(message.From.Id, message.From.FirstName);
                context.Users.Add(user);
                context.SaveChanges();
            }            
            await botClient.SendTextMessageAsync(chatId, "Hello I'm ShoppingListBot");
            if (user.Catalog.Count == 0)
                await botClient.SendTextMessageAsync(chatId, "You don't have any shopping lists, lets create your first list. Enter '/addlist' + name of list. ");
        }
    }
}