using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class StackTests
    {
        private readonly DeepComparator _deepComparator;

        public StackTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestStackEquality()
        {
            // Create two stacks with identical contents
            Stack<int> stack1 = new Stack<int>(new[] { 1, 2, 3 });
            Stack<int> stack2 = new Stack<int>(new[] { 1, 2, 3 });

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.True);
        }

        [Test]
        public void TestStackInequality()
        {
            // Create two stacks with different contents
            Stack<int> stack1 = new Stack<int>(new[] { 1, 2, 3 });
            Stack<int> stack2 = new Stack<int>(new[] { 3, 2, 1 });

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.False);
        }

        [Test]
        public void TestStackEqualityWithNull()
        {
            // Create a stack with null and another without null
            Stack<int> stack1 = new Stack<int>(new[] { 1, 2, 3 });
            Stack<int> stack2 = new Stack<int>(new[] { 1, 2, 3, 4 });

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.False);
        }

        [Test]
        public void TestStackEqualityWithNestedStacks()
        {
            // Create stacks with nested stacks
            Stack<Stack<int>> stack1 = new Stack<Stack<int>>();
            stack1.Push(new Stack<int>(new[] { 1, 2, 3 }));
            stack1.Push(new Stack<int>(new[] { 4, 5 }));

            Stack<Stack<int>> stack2 = new Stack<Stack<int>>();
            stack2.Push(new Stack<int>(new[] { 1, 2, 3 }));
            stack2.Push(new Stack<int>(new[] { 4, 5 }));

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.True);
        }

        [Test]
        public void TestStackOfPersonsEquality()
        {
            // Create two stacks with identical Person objects
            var person1 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Home", Number = "555-1234" } }
            };

            var person2 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Home", Number = "555-1234" } }
            };

            Stack<Person> stack1 = new Stack<Person>();
            stack1.Push(person1);

            Stack<Person> stack2 = new Stack<Person>();
            stack2.Push(person2);

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.True);
        }

        [Test]
        public void TestStackOfPersonsInequality()
        {
            // Create two stacks with different Person objects
            var person1 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Home", Number = "555-1234" } }
            };

            var person2 = new Person
            {
                Name = "Bob",
                Age = 25,
                Residence = new Address { Street = "456 Oak Ave", City = "Othertown" },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Mobile", Number = "555-5678" } }
            };

            Stack<Person> stack1 = new Stack<Person>();
            stack1.Push(person1);

            Stack<Person> stack2 = new Stack<Person>();
            stack2.Push(person2);

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.False);
        }

        [Test]
        public void TestStackOfPersonsWithNullValues()
        {
            // Create two stacks with Person objects containing null values
            var person1 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = null,
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Home", Number = "555-1234" } }
            };

            var person2 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = null,
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Home", Number = "555-1234" } }
            };

            Stack<Person> stack1 = new Stack<Person>();
            stack1.Push(person1);

            Stack<Person> stack2 = new Stack<Person>();
            stack2.Push(person2);

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.True);
        }

        [Test]
        public void TestStackOfPersonsWithDifferentLengths()
        {
            // Create two stacks with different lengths of Person objects
            var person1 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Home", Number = "555-1234" } }
            };

            var person2 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" },
                PhoneNumbers = new List<PhoneNumber> { new PhoneNumber { Type = "Home", Number = "555-1234" } }
            };

            Stack<Person> stack1 = new Stack<Person>();
            stack1.Push(person1);

            Stack<Person> stack2 = new Stack<Person>();
            stack2.Push(person2);
            stack2.Push(person2); // Make stack2 longer

            Assert.That(_deepComparator.DeepEquals(stack1, stack2), Is.False);
        }
    }
}
