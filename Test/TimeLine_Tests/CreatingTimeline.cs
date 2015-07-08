using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace Test.Wall_Tests
{
    [TestClass]
    public class CreatingTimeline
    {
        [TestMethod]
        public void TestCountAfterAdding2Messages()
        {
            var wall = new Timeline();

            var msg1 = TestHelper.CreateMessage(1);
            var msg2 = TestHelper.CreateMessage(2);

            wall.Add(msg1);
            wall.Add(msg2);

            Assert.AreEqual(2, wall.Count);
        }

        [TestMethod]
        public void TestContentOfAddedMessage()
        {
            var wall = new Timeline();

            var msg1 = TestHelper.CreateMessage(1);            

            wall.Add(msg1);            

            Assert.AreEqual(msg1.Content, wall[0].Content);
            Assert.AreEqual(msg1.DateCreated, wall[0].DateCreated);
        }

        [TestMethod]
        public void TestDisplayingTimeOfMessage5Minutes()
        {
            var msg = new Message("test", DateTime.Now.AddMinutes(-5), "user1");
            var wall = new Timeline();
            wall.Add(msg);

            StringAssert.EndsWith(wall[0].ToString(), "(5 minutes ago)");
        }

        [TestMethod]
        public void TestDisplayingTimeOfMessage1Minute()
        {
            var msg = new Message("test", DateTime.Now.AddMinutes(-1), "user1");
            var wall = new Timeline();
            wall.Add(msg);

            StringAssert.EndsWith(wall[0].ToString(), "(1 minute ago)");
        }

        [TestMethod]
        public void TestDisplayingTimeOfMessage30Seconds()
        {
            var msg = new Message("test", DateTime.Now.AddSeconds(-30), "user1");
            var wall = new Timeline();
            wall.Add(msg);

            StringAssert.EndsWith(wall[0].ToString(), "(30 seconds ago)");
        }

        [TestMethod]
        public void TestDisplayingTimeOfMessage1Hour()
        {
            var msg = new Message("test", DateTime.Now.AddMinutes(-65), "user1");
            var wall = new Timeline();
            wall.Add(msg);

            StringAssert.EndsWith(wall[0].ToString(), "(1 hour ago)");
        }

        [TestMethod]
        public void TestDisplayingTimeOfMessage2Hours()
        {
            var msg = new Message("test", DateTime.Now.AddMinutes(-125), "user1");
            var wall = new Timeline();
            wall.Add(msg);

            StringAssert.EndsWith(wall[0].ToString(), "(2 hours ago)");
        }

        [TestMethod]
        public void TestOrderOfMessages()
        {
            var msg1 = new Message("test1", DateTime.Now.AddMinutes(-10), "user1");
            var msg2 = new Message("test2", DateTime.Now.AddMinutes(-5), "user1");
            var wall = new Timeline();
            wall.Add(msg1);
            wall.Add(msg2);

            List<Message> messages = new List<Message>();

            foreach(var message in wall)
            {
                messages.Add(message);
            }
            // reversed order
            StringAssert.StartsWith(messages[0].ToString(), "test2");
            StringAssert.StartsWith(messages[1].ToString(), "test1");
            
        }


        
    }
}
