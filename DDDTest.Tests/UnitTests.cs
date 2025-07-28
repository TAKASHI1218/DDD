
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Domain;
using System.Security.AccessControl;

namespace DDDTest.Tests2
{
    [TestClass]
    public partial class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var val = DDD.Domain.Common.Class1.Add(1, 2);
            Assert.AreEqual(val, 3);
        }
    }
}
