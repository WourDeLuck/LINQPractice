using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LINQPractice;

namespace LINQPractice.Tests
{
    [TestClass]
    public class UserMethodTest
    {
        [TestMethod]
        public void CalculateAge_Test()
        {
            DateTime dob = new DateTime(1962, 11, 3);
            User user = new User(1, "Gabe", "Newell", dob);

            Assert.AreEqual(55, user.Age);
        }

        [TestMethod]
        public void CalculateAge_OneMoreTest()
        {
            DateTime dob = new DateTime(2001, 1, 3);
            User user = new User(1, "Nick", "Scrooge", dob);

            Assert.AreNotEqual(18, user.Age);
        }
    }
}
