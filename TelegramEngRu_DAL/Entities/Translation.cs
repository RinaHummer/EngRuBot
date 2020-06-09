using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramEngRu_DAL.Entities
{
    public class Translation : IKeyId
    {
        [Key, Required]
        public int Id { get; set; }
        public string WordRu { get; set; }
        public string WordEn { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public BotUser BotUser { get; set; }
    }
}
