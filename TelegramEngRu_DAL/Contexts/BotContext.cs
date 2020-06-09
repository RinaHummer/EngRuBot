using Microsoft.EntityFrameworkCore;
using TelegramEngRu_DAL.Entities;

namespace TelegramEngRu_DAL.Contexts
{
    public class BotContext : DbContext
    {
        public DbSet<Translation> Translations { get; set; }
        public DbSet<BotUser> Users { get; set; }

        public BotContext(DbContextOptions<BotContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
