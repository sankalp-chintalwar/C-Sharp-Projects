using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class ArrayTests
    {
        private DeepComparator _deepComparator;

        public ArrayTests()
        {
            _deepComparator = new DeepComparator();
        }

        // Test cases for int[] arrays
        [Test]
        public void TestIntArrayEquality()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 1, 2, 3 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestIntArrayInequality()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 1, 2, 4 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        [Test]
        public void TestIntArrayDifferentLengths()
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 1, 2, 3, 4 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        // Test cases for string[] arrays
        [Test]
        public void TestStringArrayEquality()
        {
            string[] a = { "a", "b", "c" };
            string[] b = { "a", "b", "c" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestStringArrayInequality()
        {
            string[] a = { "a", "b", "c" };
            string[] b = { "a", "b", "d" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        [Test]
        public void TestStringArrayDifferentLengths()
        {
            string[] a = { "a", "b", "c" };
            string[] b = { "a", "b", "c", "d" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        // Test cases for arrays of Address structs
        [Test]
        public void TestStructArrayEquality()
        {
            Address[] a =
            {
                new Address { Street = "123 Main St", City = "Anytown" },
                new Address { Street = "456 Oak Ave", City = "Othertown" }
            };
            Address[] b =
            {
                new Address { Street = "123 Main St", City = "Anytown" },
                new Address { Street = "456 Oak Ave", City = "Othertown" }
            };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestStructArrayInequality()
        {
            Address[] a =
            {
                new Address { Street = "123 Main St", City = "Anytown" },
                new Address { Street = "456 Oak Ave", City = "Othertown" }
            };
            Address[] b =
            {
                new Address { Street = "123 Main St", City = "Anytown" },
                new Address { Street = "789 Elm St", City = "Anycity" }
            };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        // Test cases for jagged arrays
        [Test]
        public void TestJaggedArrayEquality()
        {
            int[][] a = { new int[] { 1, 2 }, new int[] { 3, 4 } };
            int[][] b = { new int[] { 1, 2 }, new int[] { 3, 4 } };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestJaggedArrayInequality()
        {
            int[][] a = { new int[] { 1, 2 }, new int[] { 3, 4 } };
            int[][] b = { new int[] { 1, 2 }, new int[] { 3, 5 } };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        [Test]
        public void TestJaggedArrayEquality_WithoutOrder()
        {
            int[][] a = { new int[] { 1, 2 }, new int[] { 3, 4 } };
            int[][] b = { new int[] { 3, 4 }, new int[] { 1, 2 } };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestJaggedArrayEquality_WithoutOrderInChildArray()
        {
            int[][] a = { new int[] { 1, 2 }, new int[] { 3, 4 } };
            int[][] b = { new int[] { 2, 1 }, new int[] { 4, 3 } };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }
    }
}
