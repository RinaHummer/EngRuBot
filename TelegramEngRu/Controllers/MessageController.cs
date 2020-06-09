using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramEngRu.Models;

namespace TelegramEngRu.Controllers
{
    public class MessageController : ApiController
    {
        [Route(@"api/message/update/")]
        public async Task<OkResult> Update([FromBody]Update update)
        {
            Message message;

            if (update == null)
            {
                return Ok();
            }
            else if (update.CallbackQuery != null)
            {
                message = update.CallbackQuery.Message;
                message.Text = update.CallbackQuery.Data + message.Text;
            }
            else
            {
                message = update.Message;
            }

            var client = await Bot.Get();
            
            var commands = Bot.Commands;
            bool IsExecuted = false;

            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    string text = command.Execute(message);
                    client.SendTextMessageAsync(message.Chat.Id, text, replyToMessageId: message.MessageId);
                    IsExecuted = true;
                    break;
                }
            }

            if (!IsExecuted)
            {
                string text = Bot.DefaultCommand.Execute(message);
                InlineKeyboardMarkup addButtonMarkUp = Bot.CreateButton("Добавить в словарь", "/add ");
                client.SendTextMessageAsync(message.Chat.Id, text, replyToMessageId: message.MessageId, replyMarkup: addButtonMarkUp);
            }

            return Ok();
        }
    }
}
