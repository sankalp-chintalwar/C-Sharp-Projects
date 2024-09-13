using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    public class HashSetTests
    {
        private DeepComparator _deepComparator;

        public HashSetTests()
        {
            _deepComparator = new DeepComparator();
        }

        // Test cases for simple HashSet with primitive types
        [Test]
        public void TestPrimitiveHashSetEquality()
        {
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int> { 1, 2, 3 };

            Assert.That(_deepComparator.DeepEquals(set1, set2), Is.True);
        }

        [Test]
        public void TestPrimitiveHashSetInequality()
        {
            HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
            HashSet<int> set2 = new HashSet<int> { 3, 2, 1 };

            Assert.That(_deepComparator.DeepEquals(set1, set2), Is.True);
        }

        // Test cases for HashSet with complex types (nested HashSet)
        [Test]
        public void TestComplexHashSetEquality()
        {
            var address1 = new Address { Street = "123 Main St", City = "Anytown" };
            var address2 = new Address { Street = "456 Oak Ave", City = "Othertown" };

            HashSet<Address> set1 = new HashSet<Address>
        {
            address1,
            address2
        };

            HashSet<Address> set2 = new HashSet<Address>
        {
            address2,
            address1
        };

            Assert.That(_deepComparator.DeepEquals(set1, set2), Is.True);
        }

        [Test]
        public void TestComplexHashSetInequality()
        {
            var address1 = new Address { Street = "123 Main St", City = "Anytown" };
            var address2 = new Address { Street = "456 Oak Ave", City = "Othertown" };

            HashSet<Address> set1 = new HashSet<Address>
        {
            address1
        };

            HashSet<Address> set2 = new HashSet<Address>
        {
            address2
        };

            Assert.That(_deepComparator.DeepEquals(set1, set2), Is.False);
        }

        // Test cases for HashSet with null values
        [Test]
        public void TestHashSetWithNullValuesEquality()
        {
            HashSet<string?> set1 = new HashSet<string?> { null, "two", "three" };
            HashSet<string?> set2 = new HashSet<string?> { null, "two", "three" };

            Assert.That(_deepComparator.DeepEquals(set1, set2), Is.True);
        }

        [Test]
        public void TestHashSetWithNullValuesInequality()
        {
            HashSet<string?> set1 = new HashSet<string?> { null, "two", "three" };
            HashSet<string?> set2 = new HashSet<string?> { "null", "two", "three" }; // "null" as string, not actual null

            Assert.That(_deepComparator.DeepEquals(set1, set2), Is.False);
        }
    }
}
