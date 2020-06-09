using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramEngRu_DAL.Contexts
{
    public class SqlServerContext : BotContext
    {
        private static readonly DbContextOptions<BotContext> Options;
        static SqlServerContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<BotContext>().UseSqlServer(connectionString);
            Options = optionsBuilder.Options;
        }

        public SqlServerContext() : base(Options)
        {
            Database.EnsureCreated();
        }
    }
}
