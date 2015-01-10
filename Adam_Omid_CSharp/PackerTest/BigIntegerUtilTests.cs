using System.Numerics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiedPiper;

namespace PackerTest
{
    [TestClass]
    public class BigIntegerUtilTests
    {
        [TestMethod]
        public void Factorial()
        {
            Assert.AreEqual(1, new BigInteger(0).Factorial());
            Assert.AreEqual(1, new BigInteger(1).Factorial());
            Assert.AreEqual(2, new BigInteger(2).Factorial());
            Assert.AreEqual(120, new BigInteger(5).Factorial());
            Assert.AreEqual(3628800, new BigInteger(10).Factorial());
            Assert.AreEqual(87178291200, new BigInteger(14).Factorial());
        }
    }
}
