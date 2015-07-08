using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class SocialNetwork : Logic.ISocialNetwork
    {
        private Dictionary<string, Timeline> _Profiles;

        public SocialNetwork()
        {
            _Profiles = new Dictionary<string, Timeline>();
        }

        #region Public Methods

        public void Post(string userName, string message)
        {
            var msg = new Message(message, DateTime.Now, userName);
            Post(msg);            
        }                
   
        public List<string> Read(string userName)
        {
            List<string> ret = null;

            var messages = ReadMessages(userName);
            if(messages != null)
            {
                ret = new List<string>();
                foreach (var msg in messages)
                {
                    ret.Add(msg.ToString());
                }
            }

            return ret;
        }

        public bool Follow(string follower, string followee)
        {
            if (!string.IsNullOrEmpty(follower) && !string.IsNullOrEmpty(followee))
            {
                var profile = GetProfile(follower);
                if (profile != null)
                {
                    return profile.Follow(followee);
                }
            }

            return false;
        }

        public List<string> Wall(string userName)
        {
            var ret = new List<string>();

            var allMessagesWall = GetAllMessagesPerUser(userName);

            if (allMessagesWall != null)
            {
                var allMessages = allMessagesWall.GetAll();
                foreach (var message in allMessages)
                {
                    ret.Add(message.ToString(Message.MessageFormat.AuthorMessageTime));
                }
            }

            return ret;
        }

        #endregion

        private void Post(Message msg)
        {
            if (_Profiles == null)
            {
                throw new Exception("Social network not inistialised!");
            }
            if (msg == null)
            {
                throw new ArgumentNullException("Message is null!");
            }

            var wall = GetProfile(msg.Author);
            if (wall != null)
            {
                wall.Add(msg);
            }
            else
            {
                wall = new Timeline();
                wall.Add(msg);
                _Profiles.Add(msg.Author, wall);
            }
        }           

        private Timeline GetProfile(string userName)
        {
            if (_Profiles == null)
            {
                throw new Exception("Social network not inistialised!");
            }

            if (_Profiles.ContainsKey(userName))
            {
                return _Profiles[userName];
            }

            return null;
        }

        private List<Message> ReadMessages(string userName)
        {
            List<Message> ret = null;

            var wall = GetProfile(userName);
            if (wall != null)
            {
                ret = wall.GetAll();
            }

            return ret;
        }  
                
        private Timeline GetAllMessagesPerUser(string userName)
        {
            Timeline allMessages = null;

            var profile = GetProfile(userName);
            if (profile != null)
            {
                allMessages = new Timeline();

                allMessages.AddRange(profile.GetAll());
                foreach (var followee in profile.Followees)
                {
                    var folProfile = GetProfile(followee);
                    if (folProfile != null)
                    {
                        allMessages.AddRange(folProfile.GetAll());
                    }
                }                
            }

            return allMessages;
        }
    }
}
