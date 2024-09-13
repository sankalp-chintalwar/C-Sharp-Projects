using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;
using System.Collections;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    public class ArrayListTests
    {
        private readonly DeepComparator _deepComparator;
        public ArrayListTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestArrayListEquality()
        {
            var list1 = new ArrayList { 1, "two", 3.0 };
            var list2 = new ArrayList { 1, "two", 3.0 };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListInequality_OrderInsensitive()
        {
            var list1 = new ArrayList { 1, "two", 3.0 };
            var list2 = new ArrayList { "two", 1, 3.0 };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListInequality_NullValues()
        {
            var list1 = new ArrayList { 1, "two", null };
            var list2 = new ArrayList { 1, "two", "three" };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }

        [Test]
        public void TestArrayListInequality_DifferentLengths()
        {
            var list1 = new ArrayList { 1, "two", 3.0 };
            var list2 = new ArrayList { 1, "two" };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }

        [Test]
        public void TestArrayListEquality_WithNestedArrayLists()
        {
            var innerList1 = new ArrayList { 1, 2, 3 };
            var innerList2 = new ArrayList { 1, 2, 3 };
            var list1 = new ArrayList { "one", innerList1, "three" };
            var list2 = new ArrayList { "one", innerList2, "three" };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListEquality_WithNullValues()
        {
            var list1 = new ArrayList { null, "two", 3.0 };
            var list2 = new ArrayList { null, "two", 3.0 };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListEquality_WithStructs()
        {
            var list1 = new ArrayList
            {
                new Address { Street = "123 Main St", City = "Anytown" },
                new Address { Street = "456 Oak Ave", City = "Othertown" }
            };
            var list2 = new ArrayList
            {
                new Address { Street = "123 Main St", City = "Anytown" },
                new Address { Street = "456 Oak Ave", City = "Othertown" }
            };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListInequality_WithStructs()
        {
            var list1 = new ArrayList { new Address { Street = "123 Main St", City = "Anytown" } };
            var list2 = new ArrayList { new Address { Street = "456 Oak Ave", City = "Othertown" } };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }

        [Test]
        public void TestArrayListEquality_WithClasses()
        {
            var list1 = new ArrayList
            {
                new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
                new Person { Name = "Bob", Age = 25, Residence = new Address { Street = "456 Oak Ave", City = "Othertown" } }
            };
            var list2 = new ArrayList
            {
                new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
                new Person { Name = "Bob", Age = 25, Residence = new Address { Street = "456 Oak Ave", City = "Othertown" } }
            };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListInequality_WithClasses()
        {
            var list1 = new ArrayList
            {
                new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } }
            };
            var list2 = new ArrayList
            {
                new Person { Name = "Bob", Age = 25, Residence = new Address { Street = "456 Oak Ave", City = "Othertown" } }
            };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }

        [Test]
        public void TestArrayListEquality_WithMixedTypes()
        {
            var list1 = new ArrayList
            {
                new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
                new Address { Street = "456 Oak Ave", City = "Othertown" }
            };
            var list2 = new ArrayList
            {
                new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
                new Address { Street = "456 Oak Ave", City = "Othertown" }
            };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListEquality_WithClassesAndNullValues()
        {
            var list1 = new ArrayList { null, new Address { Street = "123 Main St", City = "Anytown" }, null };
            var list2 = new ArrayList { null, new Address { Street = "123 Main St", City = "Anytown" }, null };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestArrayListInequality_WithNullValues()
        {
            var list1 = new ArrayList { null, new Address { Street = "123 Main St", City = "Anytown" }, null };
            var list2 = new ArrayList { null, new Address { Street = "456 Oak Ave", City = "Othertown" }, null };

            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }
    }
}
