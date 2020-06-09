using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu_DAL.Entities;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Tests
{
    class TranslationRepositoryMock : RepositoryMock<Translation>, ITranslationRepository
    {
        public Translation GetByTranslation(string translationRu, int userId)
        {
            return GetUsersTranslations(userId).FirstOrDefault(translation => translation.WordRu == translationRu);
        }

        public IEnumerable<Translation> GetUsersTranslations(int userId)
        {
            return context.Values.Where(translation => translation.UserId == userId);
        }
    }
}
