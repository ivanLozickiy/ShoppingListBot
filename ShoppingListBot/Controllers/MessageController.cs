using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using ShoppingListBot.Models;

namespace ShoppingListBot.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update")]
        //[HttpPost]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            if (update == null)
                return Ok();
            var commands = Bot.Comands;
            var message = update.Message;
            var botClient = await Bot.GetBotClientAsync();
            foreach(var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    await command.Execute(message, botClient);
                    break;
                }
            }
            return Ok();
        }
    }
}
