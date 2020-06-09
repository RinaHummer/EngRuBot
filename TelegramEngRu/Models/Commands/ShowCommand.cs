using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using TelegramEngRu_DAL.Entities;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Models.Commands
{
    public class ShowCommand : Command
    {
        public override string Name => "/show";
        public ShowCommand(IUserRepository u, ITranslationRepository t) : base(u, t)
        { }

        public override string Execute(Message message)
        {
            BotUser user = userRepo.GetByChatId(message.Chat.Id);
            var translations = transRepo.GetUsersTranslations(user.Id).ToList();
            var text = FormatList(translations);
            return text;
        }

        public string FormatList(List<Translation> translations)
        {

            string text = "";
            for (int i = 0; i < translations.Count; i++)
            {
                text += (i + 1).ToString() + ". " + translations[i].WordRu + " // " + translations[i].WordEn + "\n";
            }
            return text;
        }
    }
}