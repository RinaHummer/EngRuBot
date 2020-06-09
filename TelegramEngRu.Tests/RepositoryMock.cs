using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu_DAL.Entities;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Tests
{
    public abstract class RepositoryMock<T> : IRepository<T>
         where T : class, IKeyId
    {
        public Dictionary<int, T> context;

        public RepositoryMock()
        {
            context = new Dictionary<int, T>();
        }

        public void Create(T item)
        {
            context.Add(item.Id, item);
        }

        
        public void Delete(int id)
        {
            context.Remove(id);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Values;
        }

        public T GetSingle(int id)
        {
            return context[id];
        }


        public void Save()
        {
            
        }

        public void Update(T item)
        {
            context[item.Id] = item;
        }
    }
}
