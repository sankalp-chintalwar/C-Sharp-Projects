using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class EnumTests
    {
        private DeepComparator _deepComparator;

        public EnumTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestEnumEquality()
        {
            Colors color1 = Colors.Red;
            Colors color2 = Colors.Red;
            Assert.That(_deepComparator.DeepEquals(color1, color2), Is.True);
        }

        [Test]
        public void TestEnumInequality()
        {
            Colors color1 = Colors.Red;
            Colors color2 = Colors.Green;
            Assert.That(_deepComparator.DeepEquals(color1, color2), Is.False);
        }

    }
}
