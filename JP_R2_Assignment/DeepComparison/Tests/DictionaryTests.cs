using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    public class DictionaryTests
    {
        private DeepComparator _deepComparator;

        public DictionaryTests()
        {
            _deepComparator = new DeepComparator();
        }

        // Test cases for simple dictionaries with primitive types
        [Test]
        public void TestPrimitiveDictionaryEquality()
        {
            Dictionary<int, string> dict1 = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" }
        };
            Dictionary<int, string> dict2 = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" },
            { 3, "three" }
        };

            Assert.That(_deepComparator.DeepEquals(dict1, dict2), Is.True);
        }

        [Test]
        public void TestPrimitiveDictionaryInequality()
        {
            Dictionary<int, string> dict1 = new Dictionary<int, string>
        {
            { 1, "one" },
            { 2, "two" }
        };
            Dictionary<int, string> dict2 = new Dictionary<int, string>
        {
            { 1, "one" },
            { 3, "three" }
        };

            Assert.That(_deepComparator.DeepEquals(dict1, dict2), Is.False);
        }

        // Test cases for dictionaries with complex types (nested dictionaries)
        [Test]
        public void TestComplexDictionaryEquality()
        {
            var address1 = new Address { Street = "123 Main St", City = "Anytown" };
            var address2 = new Address { Street = "456 Oak Ave", City = "Othertown" };

            Dictionary<string, Address> dict1 = new Dictionary<string, Address>
        {
            { "home", address1 },
            { "work", address2 }
        };

            Dictionary<string, Address> dict2 = new Dictionary<string, Address>
        {
            { "home", address1 },
            { "work", address2 }
        };

            Assert.That(_deepComparator.DeepEquals(dict1, dict2), Is.True);
        }

        [Test]
        public void TestComplexDictionaryInequality()
        {
            var address1 = new Address { Street = "123 Main St", City = "Anytown" };
            var address2 = new Address { Street = "456 Oak Ave", City = "Othertown" };

            Dictionary<string, Address> dict1 = new Dictionary<string, Address>
        {
            { "home", address1 },
            { "work", address2 }
        };

            Dictionary<string, Address> dict2 = new Dictionary<string, Address>
        {
            { "home", address1 },
            { "work", new Address { Street = "789 Elm St", City = "Sometown" } } // Different address
        };

            Assert.That(_deepComparator.DeepEquals(dict1, dict2), Is.False);
        }

        // Test cases for dictionaries with null values
        [Test]
        public void TestDictionaryWithNullValuesEquality()
        {
            Dictionary<int, string?> dict1 = new Dictionary<int, string?>
        {
            { 1, null },
            { 2, "two" },
            { 3, "three" }
        };

            Dictionary<int, string?> dict2 = new Dictionary<int, string?>
        {
            { 1, null },
            { 2, "two" },
            { 3, "three" }
        };

            Assert.That(_deepComparator.DeepEquals(dict1, dict2), Is.True);
        }

        [Test]
        public void TestDictionaryWithNullValuesInequality()
        {
            Dictionary<int, string?> dict1 = new Dictionary<int, string?>
        {
            { 1, null },
            { 2, "two" },
            { 3, "three" }
        };

            Dictionary<int, string?> dict2 = new Dictionary<int, string?>
        {
            { 1, "null" }, // string "null" instead of actual null
            { 2, "two" },
            { 3, "three" }
        };

            Assert.That(_deepComparator.DeepEquals(dict1, dict2), Is.False);
        }
    }

}
