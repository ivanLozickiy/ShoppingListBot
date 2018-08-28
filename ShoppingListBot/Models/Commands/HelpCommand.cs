using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ShoppingListBot.Models.Commands
{
    public class HelpCommand : Command
    {
        public override string Name => @"/help";

        //public override bool Contains(Message message)
        //{
        //    if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
        //        return false;
        //    return message.Text.Contains(this.Name);
        //}

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            //System.Diagnostics.Debug.WriteLine("===========================================");
            //System.Diagnostics.Debug.WriteLine(chatId);
            //System.Diagnostics.Debug.WriteLine("===========================================");
            await botClient.SendTextMessageAsync(chatId, "Помоги себе сам))");

        }
    }
}