using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telegram.Bot.Types;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Models.Commands
{
    public abstract class Command
    {
        protected readonly IUserRepository userRepo;
        protected readonly ITranslationRepository transRepo;


        public abstract string Name { get; }

        public abstract string Execute(Message message);

        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }
        public Command(IUserRepository u, ITranslationRepository t)
        {
            userRepo = u;
            transRepo = t;
        }
    }
}