using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramEngRu.Models.Commands;
using TelegramEngRu_DAL.Repositories;

namespace TelegramEngRu.Tests
{
    [TestClass]
    public class IntegrationTestsForDb
    {
        [TestMethod]
        public void CommandStart_IfNewUser_Added()
        {
            
            var context = new TestContext();
            var userRepo = new UserRepository(context);
            var transRepo = new TranslationRepository(context);
            StartCommand c = new StartCommand(userRepo, transRepo);

            c.CreateUser(21);

            var user = context.Users.First();
            Assert.AreEqual(user.ChatId, 21);
        }
    }
}
