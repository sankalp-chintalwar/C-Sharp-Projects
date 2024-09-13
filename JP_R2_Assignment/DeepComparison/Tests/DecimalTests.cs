using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class DecimalTests
    {
        private DeepComparator _deepComparator;

        public DecimalTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestDecimalEquality()
        {
            decimal a = 5.0m;
            decimal b = 5.0m;
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestDecimalInequality()
        {
            decimal a = 5.0m;
            decimal b = 10.0m;
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }
    }
}
