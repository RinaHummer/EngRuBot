using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramEngRu.Models.Commands;
using TelegramEngRu_DAL.Entities;

namespace TelegramEngRu.Tests
{
    [TestClass]
    public class CommandUnitTests
    {
        [TestMethod]
        public void CommandStart_CreateUser_IfNewUser_Added()
        {
            var userRepo = new UserRepositoryMock();
            var transRepo = new TranslationRepositoryMock();
            var startCommand = new StartCommand(userRepo, transRepo);

            startCommand.CreateUser(21);
            var result = userRepo.context.First().Value;

            Assert.AreEqual(result.Id, 0);
            Assert.AreEqual(result.ChatId, 21);           
        }

        [TestMethod]
        public void CommandStart_CreateUser_ExistedUser_NotAdded()
        {
            var userRepo = new UserRepositoryMock();
            var transRepo = new TranslationRepositoryMock();
            var startCommand = new StartCommand(userRepo, transRepo);
            userRepo.Create(new BotUser { Id = 0, ChatId = 21 });

            startCommand.CreateUser(21);
            var result = userRepo.context;

            Assert.AreEqual(result.Count, 1);
        }


    }
}
