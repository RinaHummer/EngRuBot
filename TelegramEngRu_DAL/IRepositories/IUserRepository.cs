using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu_DAL.Entities;

namespace TelegramEngRu_DAL.IRepositories
{
    public interface IUserRepository : IRepository<BotUser>
    {
        BotUser GetByChatId(long chatId);
    }
}
