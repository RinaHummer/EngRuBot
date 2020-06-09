using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu_DAL.Entities;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Tests
{
    class UserRepositoryMock : RepositoryMock<BotUser>, IUserRepository
    {
        public BotUser GetByChatId(long chatId)
        {
            return context.Values.FirstOrDefault(botUser => botUser.ChatId == chatId);
        }
    }
}
