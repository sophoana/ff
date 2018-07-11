using System;
using FF.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace FF.UnitTests.OldTests
{
    /// <summary>
    /// Warning, bad code ahead.
    /// </summary>
    [TestClass]
    [Ignore]
    public class BaseServiceTests
    {

        [TestMethod]
        public void TestConstructor()
        {
            var target = Mock.Create<BaseService>();
            Assert.IsNotNull(target);
        }

        private class ConcreteService : BaseService
        {

        }

        [TestMethod]
        public void TestLogUserInfo()
        {
            var target = new PrivateAccessor(new ConcreteService());
            var result = target.CallMethod("LogUserInfo", "172.217.1.174");
            Assert.IsInstanceOfType(result, typeof(bool));
            Assert.IsTrue((bool)result);
        }

        [TestMethod]
        public void TestBadIpAddress()
        {
            var target = new PrivateAccessor(new ConcreteService());
            try
            {
                var result = target.CallMethod("LogUserInfo", "");
                Assert.Fail("Should have failed");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "The call to ipinfo faied");
            }
        }

        [TestMethod]
        public void LogPropertyTest()
        {
            var target = new PrivateAccessor(new ConcreteService());
            var log = target.GetProperty("_log");
            Assert.IsNotNull(log);
            Assert.AreEqual("NLog.Logger", ((NLog.Logger) log).ToString());
        }

        [TestMethod]
        public void LastIpLookedUpTest()
        {
            var target = new PrivateAccessor(new ConcreteService());
            var result = target.CallMethod("LogUserInfo", "123.123.123.123");
            Assert.AreEqual("123.123.123.123", target.GetField("_lastIpLookedUp"));
        }
    }
}
