using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class NullableTypesTests
    {
        private DeepComparator _deepComparator;
        
        public NullableTypesTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestNullableIntEquality()
        {
            int? a = 5;
            int? b = 5;
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestNullableIntInequality()
        {
            int? a = 5;
            int? b = 10;
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        [Test]
        public void TestNullableIntNullEquality()
        {
            int? a = null;
            int? b = null;
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestNullableIntNullInequality()
        {
            int? a = 5;
            int? b = null;
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }
    }
}
