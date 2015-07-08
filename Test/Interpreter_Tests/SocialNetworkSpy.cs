using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace Test.Interpreter_Tests
{
    public class SocialNetworkSpy : ISocialNetwork
    {
        public bool FollowCalled { get; private set; }
        public bool PostCalled { get; private set; }
        public bool ReadCalled { get; private set; }
        public bool WallCalled { get; private set; }

        public bool Follow(string follower, string followee)
        {
            FollowCalled = true;
            return true;
        }

        public void Post(string userName, string message)
        {
            PostCalled = true;
        }

        public List<string> Read(string userName)
        {
            ReadCalled = true;
            return new List<string>();
        }

        public List<string> Wall(string userName)
        {
            WallCalled = true;
            return new List<string>();
        }
    }
}
