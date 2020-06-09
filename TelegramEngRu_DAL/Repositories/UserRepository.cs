using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu_DAL.Contexts;
using TelegramEngRu_DAL.Entities;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu_DAL.Repositories
{
    public class UserRepository : Repository<BotUser>, IUserRepository
    {
        public UserRepository(BotContext context) : base(context)
        { }

        public BotUser GetByChatId(long chatId)
        {
            return Db.Users.FirstOrDefault(botUser => botUser.ChatId == chatId);
        }
    }
}
