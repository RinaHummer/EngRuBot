using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

using TelegramEngRu.Models.Commands;
using TelegramEngRu_DAL.Contexts;
using TelegramEngRu_DAL.Repositories;

namespace TelegramEngRu.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;
        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();
        public static Command DefaultCommand { get; private set; }

        public async static Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }
            else
            {

                BotContext context = new SqlServerContext();
                //commandsList = new List<Command>();
                //DefaultCommand = new TranslateCommand(new UserRepository(context), new TranslationRepository(context));
                //commandsList.Add(new StartCommand(new UserRepository(context), new TranslationRepository(context)));
                //commandsList.Add(new ShowCommand(new UserRepository(context), new TranslationRepository(context)));
                //commandsList.Add(new AddCommand(new UserRepository(context), new TranslationRepository(context)));

                client = new TelegramBotClient(Settings.Key);
                client.SendTextMessageAsync(437653006, "+");
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string webhook = Settings.Url + @"/api/message/update/";
                await client.SetWebhookAsync(webhook);

                return client;
            }
        }



        public static InlineKeyboardMarkup CreateButton(string name, string callback)
        {

            InlineKeyboardMarkup inlineKeyboardMarkup;
            InlineKeyboardButton butt = new InlineKeyboardButton();
            butt.Text = name;
            butt.CallbackData = callback;
            inlineKeyboardMarkup = new InlineKeyboardMarkup(butt);
            return inlineKeyboardMarkup;
        }
    }
}