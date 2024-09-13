using NUnit.Framework;
using System.Collections.Generic;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    public class ListTests
    {
        private DeepComparator _deepComparator;

        public ListTests()
        {
            _deepComparator = new DeepComparator();
        }

        // Test cases for int lists (order not considered)
        [Test]
        public void TestIntListEquality_OrderNotConsidered()
        {
            List<int> a = new List<int> { 1, 2, 3 };
            List<int> b = new List<int> { 3, 2, 1 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestIntListInequality_OrderNotConsidered()
        {
            List<int> a = new List<int> { 1, 2, 3 };
            List<int> b = new List<int> { 1, 2, 4 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        [Test]
        public void TestIntListDifferentLengths_OrderNotConsidered()
        {
            List<int> a = new List<int> { 1, 2, 3 };
            List<int> b = new List<int> { 1, 2, 3, 4 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        // Test cases for string lists (order not considered)
        [Test]
        public void TestStringListEquality_OrderNotConsidered()
        {
            List<string> a = new List<string> { "a", "b", "c" };
            List<string> b = new List<string> { "c", "b", "a" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestStringListInequality_OrderNotConsidered()
        {
            List<string> a = new List<string> { "a", "b", "c" };
            List<string> b = new List<string> { "a", "b", "d" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        [Test]
        public void TestStringListDifferentLengths_OrderNotConsidered()
        {
            List<string> a = new List<string> { "a", "b", "c" };
            List<string> b = new List<string> { "a", "b", "c", "d" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }
    }

}
