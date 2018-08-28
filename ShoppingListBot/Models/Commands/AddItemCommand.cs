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
        public override string Name => @"/add";

        public override Task Execute(Message message, TelegramBotClient client)
        {
            throw new NotImplementedException();
        }
    }
}