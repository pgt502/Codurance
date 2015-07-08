using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Message
    {
        public string Content { get; private set; }

        public DateTime DateCreated { get; private set; }

        public string Author { get; private set; }

        public Message(string message, DateTime dateTime, string author)
        {        
            this.Content = message;
            this.DateCreated = dateTime;
            this.Author = author;
        }

        public enum MessageFormat
        {
            Message,
            MessageTime,
            AuthorMessageTime
        }

        public override string ToString()
        {
            return ToString(MessageFormat.MessageTime);
        }

        public string ToString(MessageFormat format = MessageFormat.MessageTime)
        {
            var diff = DateTime.Now - DateCreated;

            switch (format)
            {
                case MessageFormat.MessageTime:
                default:
                    if (diff.Hours > 0)
                    {

                        return string.Format("{0} ({1} hour{2} ago)", Content, diff.Hours, diff.Hours > 1 ? "s" : "");

                    }
                    if (diff.Minutes > 0)
                    {
                        return string.Format("{0} ({1} minute{2} ago)", Content, diff.Minutes, diff.Minutes > 1 ? "s" : "");
                    }
                    return string.Format("{0} ({1} second{2} ago)", Content, diff.Seconds, diff.Seconds > 1 ? "s" : "");

                case MessageFormat.AuthorMessageTime:
                    if (diff.Hours > 0)
                    {
                        return string.Format("{0} - {1} ({2} hour{3} ago)", Author, Content, diff.Hours, diff.Hours > 1 ? "s" : "");
                    }
                    if (diff.Minutes > 0)
                    {
                        return string.Format("{0} - {1} ({2} minute{3} ago)", Author, Content, diff.Minutes, diff.Minutes > 1 ? "s" : "");
                    }
                    return string.Format("{0} - {1} ({2} second{3} ago)", Author, Content, diff.Seconds, diff.Seconds > 1 ? "s" : "");

                case MessageFormat.Message:
                    return Content;                    

            }

        }
        
    }
}
