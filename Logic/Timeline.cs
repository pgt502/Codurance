using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Timeline : IEnumerable<Message>
    {
        private List<Message> _Messages { get; set; }

        public List<string> Followees { get; private set; }

        public Timeline()
        {
            _Messages = new List<Message>();
            Followees = new List<string>();
        }

        public void Add(Message msg)
        {
            _Messages.Add(msg);
        }

        public void AddRange(IEnumerable<Message> messages)
        {
            if(messages != null)
            {
                _Messages.AddRange(messages);
            }
        }

        public bool Follow(string userName)
        {
            if(!Followees.Contains(userName))
            {
                Followees.Add(userName);

                return true;
            }

            return false;
        }

        public void Unfollow(string userName)
        {

        }

        public List<Message> GetAll()
        {
            var messagesDescending = _Messages.OrderByDescending(d => d.DateCreated).ToList();
            return messagesDescending;
        }

        public Message this[int index]
        {
            get
            {
                if(_Messages != null && index >= 0 && _Messages.Count >= index - 1)
                {
                    return _Messages[index];
                }

                return null;
            }
            
        }

        public int Count 
        { 
            get
            {
                if(_Messages != null)
                {
                    return _Messages.Count;
                }

                return 0;
            }
        }

        public IEnumerator<Message> GetEnumerator()
        {
            if(_Messages != null)
            {
                //var messagesDescending = _Messages.OrderByDescending(d => d.DateCreated);

                var messagesDescending = GetAll();
                foreach (var msg in messagesDescending)
                {
                    yield return msg;
                }
            }
        }



        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        
    }
}
