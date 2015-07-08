using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;


namespace Test.Interpreter_Tests
{
    [TestClass]
    public class TestingRegEx
    {
        [TestMethod]
        public void TestPostingRegEx()
        {
            var interpreter = new InterpreterDummy(Constants.RegMain);
            interpreter.Execute("Alice -> I love the weather today");

            StringAssert.Equals("Alice", interpreter.Name);
            StringAssert.Equals("I love the weather today", interpreter.Message);
            Assert.IsTrue(interpreter.Posting);
        }

        [TestMethod]
        public void TestReadingRegEx()
        {
            var interpreter = new InterpreterDummy(Constants.RegMain);
            interpreter.Execute("Alice");

            StringAssert.Equals("Alice", interpreter.Name);
            Assert.IsTrue(interpreter.Reading);
        }

        [TestMethod]
        public void TestFollowingRegEx()
        {
            var interpreter = new InterpreterDummy(Constants.RegMain);
            interpreter.Execute("Charlie follows Alice");

            StringAssert.Equals("Alice", interpreter.Followee);
            StringAssert.Equals("Charlie", interpreter.Name);
            Assert.IsTrue(interpreter.Following);
        }

        [TestMethod]
        public void TestWallRegEx()
        {
            var interpreter = new InterpreterDummy(Constants.RegMain);
            interpreter.Execute("Charlie wall");

            StringAssert.Equals("Charlie", interpreter.Name);
            Assert.IsTrue(interpreter.Wall);
        }
    }
}
