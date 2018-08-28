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
        public override string Name => @"/addList";

        public override Task Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}