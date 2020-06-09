using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramEngRu_DAL.IRepositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetSingle(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}

