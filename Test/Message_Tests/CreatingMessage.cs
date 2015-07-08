using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Test.Message_Tests
{
    [TestClass]
    public class CreatingMessage
    {
        [TestMethod]
        public void TestMessage()
        {
            var now = DateTime.Now;
            const string text = "test";

            var msg1 = new Message(text, now, "user1");

            Assert.AreEqual(text, msg1.Content);
            Assert.AreEqual(now, msg1.DateCreated);

        }
    }
}
