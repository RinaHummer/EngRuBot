using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu_DAL.Contexts;

namespace TelegramEngRu.Tests
{
    public class TestContext : BotContext
    {
        private static readonly DbContextOptions<BotContext> Options;
        static TestContext()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TestConnectionString"].ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<BotContext>().UseSqlServer(connectionString);
            Options = optionsBuilder.Options;
        }

        public TestContext() : base(Options)
        { }
    }
}
