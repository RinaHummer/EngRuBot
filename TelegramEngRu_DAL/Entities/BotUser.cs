using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramEngRu_DAL.Entities
{
    public class BotUser : IKeyId
    {
        [Key, Required]
        public int Id { get; set; }
        public long ChatId { get; set; }

        public ICollection<Translation> Translations { get; set; }
    }
}
