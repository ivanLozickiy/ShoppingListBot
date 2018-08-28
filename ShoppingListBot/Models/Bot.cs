﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Telegram.Bot;
using ShoppingListBot.Models.Commands;

namespace ShoppingListBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commands;
        public static IReadOnlyList<Command> Comands => commands.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }
            commands = new List<Command>();
            commands.Add(new StartCommand());
            commands.Add(new HelpCommand());
            // add new commands
            botClient = new TelegramBotClient(AppSettings.Key);
            string hook = AppSettings.Url + "/api/message/update";
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}