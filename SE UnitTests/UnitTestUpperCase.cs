using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestUpperCase
    {
        [TestMethod]
        public void TestForUpperCaseRoman()
        {
            Assert.IsTrue(Beispiel.StartsWithUpperCase("H"));
            Assert.IsFalse(Beispiel.StartsWithUpperCase("h"));
        }

        [TestMethod]
        public void TestUmlauts()
        {
            Assert.IsFalse(Beispiel.StartsWithUpperCase("ß"));
            Assert.IsTrue(Beispiel.StartsWithUpperCase("ẞ"));
            Assert.IsFalse(Beispiel.StartsWithUpperCase("ä"));
            Assert.IsTrue(Beispiel.StartsWithUpperCase("Ä"));
        }

        [TestMethod]
        public void TestForEmpty()
        {
            Assert.ThrowsException<ArgumentException>(() => Beispiel.StartsWithUpperCase(""), "empty string must raise exception");
        }

        [TestMethod]
        public void TestForUpperCaseUnicode()
        {
            Assert.IsTrue(Beispiel.StartsWithUpperCase("Ω"), "Omega is upper case");
        }

        [TestMethod]
        public void TestForSmiley()
        {
            Assert.IsFalse(Beispiel.StartsWithUpperCase("❌"), "❌ Smiley declared uppercase");
        }
    }
}