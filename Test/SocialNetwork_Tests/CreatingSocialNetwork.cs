using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Threading;

namespace Test.SocialNetwork_Tests
{
    [TestClass]
    public class CreatingSocialNetwork
    {   
        [TestMethod]
        public void TestPostingAndReadingCount()
        {
            var socialNetwork = new SocialNetwork();
            var msg1 = TestHelper.CreateMessage(1);
            var text = msg1.Content;

            socialNetwork.Post(msg1.Author, msg1.Content);

            var messages = socialNetwork.Read(msg1.Author);

            Assert.AreEqual(1, messages.Count);            
        }

        [TestMethod]
        public void TestPostingAndReadingJustStringCount()
        {
            var socialNetwork = new SocialNetwork();

            socialNetwork.Post("user1", "test");

            var messages = socialNetwork.Read("user1");

            Assert.AreEqual(1, messages.Count);
        }

        [TestMethod]
        public void TestPostingAndReadingContent()
        {
            var socialNetwork = new SocialNetwork();
            var msg1 = TestHelper.CreateMessage(1);
            var text = msg1.ToString();

            socialNetwork.Post(msg1.Author, msg1.Content);

            var messages = socialNetwork.Read(msg1.Author);
                        
            Assert.AreEqual(text, messages[0]);
        }        

        [TestMethod]
        public void TestPostingAndReadingJustStringContent()
        {
            var socialNetwork = new SocialNetwork();

            socialNetwork.Post("user1", "test");

            var messages = socialNetwork.Read("user1");

            StringAssert.StartsWith(messages[0], "test");            
        }

        [TestMethod]
        public void TestPostingAndReadingMultipleUsersCount()
        {
            var socialNetwork = new SocialNetwork();

            socialNetwork.Post("user1", "test");
            socialNetwork.Post("user2", "test");

            var messages = socialNetwork.Read("user1");
            var messages2 = socialNetwork.Read("user2");

            Assert.AreEqual(1, messages.Count);
            Assert.AreEqual(1, messages2.Count);
        }

        [TestMethod]
        public void TestReadingNonExistentUser()
        {
            var socialNetwork = new SocialNetwork();
                        
            var messages = socialNetwork.Read("user1");
            
            Assert.IsNull(messages);            
        }

        [TestMethod]        
        public void TestCountForTheSameUser()
        {
            var socialNetwork = new SocialNetwork();

            socialNetwork.Post("user1", "test1");
            socialNetwork.Post("user1", "test2");
            socialNetwork.Post("user1", "test3");

            var messages = socialNetwork.Read("user1");

            Assert.AreEqual(3, messages.Count);
        }

        [TestMethod]        
        public void TestUserWallCountAfterSubscribe()
        {
            var socialNetwork = new SocialNetwork();

            socialNetwork.Post("user1", "test1");
            socialNetwork.Post("user2", "test2");
            socialNetwork.Follow("user1", "user2");
            var messages = socialNetwork.Wall("user1");

            Assert.AreEqual(2, messages.Count);            
        }

        [TestMethod]
        public void TestUserWallContentAfterSubscribe()
        {
            var socialNetwork = new SocialNetwork();

            socialNetwork.Post("user1", "test1");
            Thread.Sleep(100);
            socialNetwork.Post("user2", "test2");
            socialNetwork.Follow("user1", "user2");
            var messages = socialNetwork.Wall("user1");

            StringAssert.StartsWith(messages[0], "user2");
            StringAssert.StartsWith(messages[1], "user1");
            
        }
    }
}
