using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using TelegramEngRu_DAL.Entities;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Models.Commands
{
    public class AddCommand : Command
    {
        public override string Name => "/add";
        public AddCommand(IUserRepository u, ITranslationRepository t) : base(u, t)
        { }
        public override string Execute(Message message)
        {
            var words = message.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string ru = words[1];
            string en = words[3];
            BotUser user = userRepo.GetByChatId(message.Chat.Id);
            if (transRepo.GetByTranslation(ru, user.Id) == null)
            {
                transRepo.Create(new Translation() { WordRu = ru, WordEn = en, UserId = user.Id });
                return "Добавлено!";
            }
            else
            {
                return "Уже существует!";
            }
        }
    }
}