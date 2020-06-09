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
    public class TranslationRepository : Repository<Translation>, ITranslationRepository
    {
        public TranslationRepository(BotContext context) : base(context)
        { }

        public IEnumerable<Translation> GetUsersTranslations(int userId)
        {
            return Db.Translations.Where(translation => translation.UserId == userId);
        }
        public Translation GetByTranslation(string translationRu, int userId)
        {
            return GetUsersTranslations(userId).FirstOrDefault(translation => translation.WordRu == translationRu);
        }
    }
}
