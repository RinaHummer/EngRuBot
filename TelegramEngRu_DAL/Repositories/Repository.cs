using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu_DAL.Contexts;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu_DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        
        protected readonly BotContext Db;

        protected Repository(BotContext context)
        {
            Db = context;
        }
        public void Create(T item)
        {
            Db.Add(item);
            Db.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return Db.Set<T>();
        }

        public T GetSingle(int id)
        {
            return Db.Find<T>(id);
        }

        public void Save()
        {
            Db.SaveChanges();
        }

        public void Update(T item)
        {
            Db.Update(item);
            Db.SaveChanges();
        }
    }
}
