using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;
using Telegram.Bot.Types;
using TelegramEngRu_DAL.IRepositories;

namespace TelegramEngRu.Models.Commands
{
    public class TranslateCommand : Command
    {
        public override string Name => "/translate";
        private string Lang { get; set; }
        public TranslateCommand(IUserRepository u, ITranslationRepository t) : base(u, t)
        { }

        public override string Execute(Message message)
        {
            if (!IsLangValid(message.Text))
            {
                return "Уточните язык перевода";
            }
            else
            {
                string input = message.Text.Substring(Lang.Count());
                string translation = Translate(input);

                string messageText = (Lang == "ru") ? (translation + " // " + input) : (input + " // " + translation);
                return messageText;
            }
        }

        public bool IsLangValid(string text)
        {
            Lang = "";
            string lang = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0].ToLower();
            if (lang != "ru" && lang != "en")
            {
                return false;
            }
            else
            {
                Lang = lang;
                return true;
            }
        }
        public string Translate(string text)
        {
            //creating a GET request to GoogleTranslate and processing the result to form translation object
            string url = String.Format
            ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
             "auto", Lang, Uri.EscapeUriString(text));
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            var translationItems = jsonData[0];
            string translation = "";

            foreach (object item in translationItems)
            {
                IEnumerable translationLineObject = item as IEnumerable;
                IEnumerator translationLineString = translationLineObject.GetEnumerator();
                translationLineString.MoveNext();
                translation += string.Format(" {0}", Convert.ToString(translationLineString.Current));
            }
            translation = (translation.Length > 1) ? translation.Substring(1) : translation;
            return translation;
        }
    }
}