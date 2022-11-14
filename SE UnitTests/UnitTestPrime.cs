using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTestPrime
    {
        static int[] prim = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        [TestMethod()]
        public void IsPrimeTestException()
        {
            Assert.ThrowsException<ArgumentException>(() => Beispiel.IsPrime(-1));
        }

        [TestMethod]
        public void IsPrimeTestOnlyPrimes()
        {
            foreach (int i in prim)
                Assert.IsTrue(Beispiel.IsPrime(i));
        }

        [TestMethod]
        public void IsPrimeTestNotPrime100()
        {
            for (int i = 0; i <= 100; i++)
                if (!prim.Contains(i))
                    Assert.IsFalse(Beispiel.IsPrime(i));
        }
    }
}