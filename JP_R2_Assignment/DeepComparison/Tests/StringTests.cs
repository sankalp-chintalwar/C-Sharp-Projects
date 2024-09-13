using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class StringTests
    {
        private DeepComparator _deepComparator;

        public StringTests()
        {
            _deepComparator = new DeepComparator();
        }


        [Test]
        public void TestStringEquality()
        {
            string a = "something";
            string b = "something";
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestDecimalInequality()
        {
            string a = "something";
            string b = "nothing";
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }
    }
}
