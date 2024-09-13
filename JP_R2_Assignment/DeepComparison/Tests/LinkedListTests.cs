using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    public class LinkedListTests
    {
        private DeepComparator _deepComparator;

        public LinkedListTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestLinkedListEquality_WithIntegers()
        {
            // Create two LinkedLists with integers
            LinkedList<int> list1 = new LinkedList<int>(new[] { 1, 2, 3 });
            LinkedList<int> list2 = new LinkedList<int>(new[] { 1, 2, 3 });

            // Assert that list1 and list2 are considered equal by deep comparison, handling integers
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestLinkedListInequality_WithIntegers()
        {
            // Create two LinkedLists with integers
            LinkedList<int> list1 = new LinkedList<int>(new[] { 1, 2, 3 });
            LinkedList<int> list2 = new LinkedList<int>(new[] { 3, 2, 1 });

            // Assert that list1 and list2 are considered unequal by deep comparison due to different order
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestLinkedListEquality_WithStrings()
        {
            // Create two LinkedLists with strings
            LinkedList<string> list1 = new LinkedList<string>(new[] { "apple", "banana", "cherry" });
            LinkedList<string> list2 = new LinkedList<string>(new[] { "apple", "banana", "cherry" });

            // Assert that list1 and list2 are considered equal by deep comparison, handling strings
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestLinkedListEquality_WithMixedTypes()
        {
            // Create two LinkedLists with mixed types (integers and strings)
            LinkedList<object> list1 = new LinkedList<object>(new object[]
            {
            1,
            "apple",
            new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } }
            });

            LinkedList<object> list2 = new LinkedList<object>(new object[]
            {
            1,
            "apple",
            new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } }
            });

            // Assert that list1 and list2 are considered equal by deep comparison, handling mixed types
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        // Struct for testing
        [Test]
        public void TestLinkedListEquality_WithStructs()
        {
            // Create two LinkedLists with structs
            LinkedList<Address> list1 = new LinkedList<Address>(new[] {
            new Address { Street = "123 Main St", City = "Anytown" },
            new Address { Street = "456 Oak Ave", City = "Othertown" }
        });
            LinkedList<Address> list2 = new LinkedList<Address>(new[] {
            new Address { Street = "123 Main St", City = "Anytown" },
            new Address { Street = "456 Oak Ave", City = "Othertown" }
        });

            // Assert that list1 and list2 are considered equal by deep comparison, handling structs
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestLinkedListInequality_WithStructs()
        {
            // Create two LinkedLists with structs
            LinkedList<Address> list1 = new LinkedList<Address>(new[] {
            new Address { Street = "123 Main St", City = "Anytown" }
        });
            LinkedList<Address> list2 = new LinkedList<Address>(new[] {
            new Address { Street = "456 Oak Ave", City = "Othertown" }
        });

            // Assert that list1 and list2 are considered unequal by deep comparison due to different structs
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }

        [Test]
        public void TestLinkedListEquality_WithClasses()
        {
            // Create two LinkedLists with classes
            LinkedList<Person> list1 = new LinkedList<Person>(new[] {
            new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
            new Person { Name = "Bob", Age = 25, Residence = new Address { Street = "456 Oak Ave", City = "Othertown" } }
        });

            LinkedList<Person> list2 = new LinkedList<Person>(new[] {
            new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
            new Person { Name = "Bob", Age = 25, Residence = new Address { Street = "456 Oak Ave", City = "Othertown" } }
        });

            // Assert that list1 and list2 are considered equal by deep comparison, handling classes
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestLinkedListInequality_WithClasses()
        {
            // Create two LinkedLists with classes
            LinkedList<Person> list1 = new LinkedList<Person>(new[] {
            new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } }
        });

            LinkedList<Person> list2 = new LinkedList<Person>(new[] {
            new Person { Name = "Bob", Age = 25, Residence = new Address { Street = "456 Oak Ave", City = "Othertown" } }
        });

            // Assert that list1 and list2 are considered unequal by deep comparison due to different classes
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }

        [Test]
        public void TestLinkedListEquality_WithMixedClassesAndTypes()
        {
            // Create two LinkedLists with mixed types (class and struct)
            LinkedList<object> list1 = new LinkedList<object>(new object[]
            {
            new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
            new Address { Street = "456 Oak Ave", City = "Othertown" }
            });

            LinkedList<object> list2 = new LinkedList<object>(new object[]
            {
            new Person { Name = "Alice", Age = 30, Residence = new Address { Street = "123 Main St", City = "Anytown" } },
            new Address { Street = "456 Oak Ave", City = "Othertown" }
            });

            // Assert that list1 and list2 are considered equal by deep comparison, handling mixed types
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestLinkedListEquality_WithNullValues()
        {
            // Create two LinkedLists with null values
            LinkedList<object?> list1 = new LinkedList<object?>(new object?[]
            {
            null,
            new Address { Street = "123 Main St", City = "Anytown" },
            null
            });

            LinkedList<object?> list2 = new LinkedList<object?>(new object?[]
            {
            null,
            new Address { Street = "123 Main St", City = "Anytown" },
            null
            });

            // Assert that list1 and list2 are considered equal by deep comparison, handling null values
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.True);
        }

        [Test]
        public void TestLinkedListInequality_WithNullValues()
        {
            // Create two LinkedLists with null values
            LinkedList<object?> list1 = new LinkedList<object?>(new object?[]
            {
            null,
            new Address { Street = "123 Main St", City = "Anytown" },
            null
            });

            LinkedList<object?> list2 = new LinkedList<object?>(new object?[]
            {
            null,
            new Address { Street = "456 Oak Ave", City = "Othertown" },
            null
            });

            // Assert that list1 and list2 are considered unequal by deep comparison due to different null values
            Assert.That(_deepComparator.DeepEquals(list1, list2), Is.False);
        }
    }
}
