using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using TelegramEngRu_DAL.Entities;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Models.Commands
{
    public class StartCommand : Command
    {
        public override string Name => "/start";
        public StartCommand(IUserRepository u, ITranslationRepository t) : base(u, t)
        { }
        public override string Execute(Message message)
        {

            long user = message.Chat.Id;
            CreateUser(user);
            return "Hello!";

        }

        public void CreateUser(long user)
        {
            var userData = userRepo.GetByChatId(user);

            if (userData == null)
            {
                userRepo.Create(new BotUser() { ChatId = user });

            }
        }
    }
}