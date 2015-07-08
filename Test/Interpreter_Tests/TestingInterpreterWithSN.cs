using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;

namespace Test.Interpreter_Tests
{
    [TestClass]
    public class TestingInterpreterWithSN
    {
        [TestMethod]
        public void TestPostWasCalled()
        {
            var sn = new SocialNetworkSpy();
            var interpreter = new Interpreter(Constants.RegMain, sn);

            interpreter.Execute("Alice -> I love the weather today");
            Assert.IsTrue(sn.PostCalled);
        }

        [TestMethod]
        public void TestReadWasCalled()
        {
            var sn = new SocialNetworkSpy();
            var interpreter = new Interpreter(Constants.RegMain, sn);

            interpreter.Execute("Alice");
            Assert.IsTrue(sn.ReadCalled);
        }

        [TestMethod]
        public void TestFollowWasCalled()
        {
            var sn = new SocialNetworkSpy();
            var interpreter = new Interpreter(Constants.RegMain, sn);

            interpreter.Execute("Charlie follows Bob");
            Assert.IsTrue(sn.FollowCalled);
        }

        [TestMethod]
        public void TestWallWasCalled()
        {
            var sn = new SocialNetworkSpy();
            var interpreter = new Interpreter(Constants.RegMain, sn);

            interpreter.Execute("Charlie wall");
            Assert.IsTrue(sn.WallCalled);
        }

        [TestMethod]
        public void TestScenario()
        {
            var sn = new SocialNetwork();
            var interpreter = new Interpreter(Constants.RegMain, sn);

            interpreter.Execute("Alice -> I love the weather today");
            interpreter.Execute("Bob -> Damn! We lost!");
            interpreter.Execute("Bob -> Good game though.");
            var output = interpreter.Execute("Alice");
            StringAssert.StartsWith(output[0], "I love the weather today");

            output = interpreter.Execute("Bob");
            StringAssert.StartsWith(output[0], "Good game though.");
            StringAssert.StartsWith(output[1], "Damn! We lost!");

            interpreter.Execute("Charlie -> I'm in New York today! Anyone want to have a coffee?");
            interpreter.Execute("Charlie follows Alice");
            output = interpreter.Execute("Charlie wall");
            StringAssert.StartsWith(output[0], "Charlie - I'm in New York today! Anyone want to have a coffee?");
            StringAssert.StartsWith(output[1], "Alice - I love the weather today");

            interpreter.Execute("Charlie follows Bob");
            output = interpreter.Execute("Charlie wall");
            StringAssert.StartsWith(output[0], "Charlie - I'm in New York today! Anyone want to have a coffee?");
            StringAssert.StartsWith(output[1], "Bob - Good game though.");
            StringAssert.StartsWith(output[2], "Bob - Damn! We lost!");
            StringAssert.StartsWith(output[3], "Alice - I love the weather today");

        }
    }
}
