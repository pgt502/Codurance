using System;
namespace Logic
{
    public interface ISocialNetwork
    {
        bool Follow(string follower, string followee);
        void Post(string userName, string message);
        System.Collections.Generic.List<string> Read(string userName);
        System.Collections.Generic.List<string> Wall(string userName);
    }
}
