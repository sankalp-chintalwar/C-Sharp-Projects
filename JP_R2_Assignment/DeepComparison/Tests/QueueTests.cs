using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class QueueTests
    {
        private DeepComparator _deepComparator;

        public QueueTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestQueueOfIntegersEquality()
        {
            // Create two queues with identical integers
            Queue<int> queue1 = new Queue<int>(new[] { 1, 2, 3 });
            Queue<int> queue2 = new Queue<int>(new[] { 1, 2, 3 });

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.True);
        }

        [Test]
        public void TestQueueOfIntegersInequality()
        {
            // Create two queues with different integers
            Queue<int> queue1 = new Queue<int>(new[] { 1, 2, 3 });
            Queue<int> queue2 = new Queue<int>(new[] { 3, 2, 1 });

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.False);
        }

        [Test]
        public void TestQueueOfIntegersWithDifferentLengths()
        {
            // Create two queues with different lengths of integers
            Queue<int> queue1 = new Queue<int>(new[] { 1, 2, 3 });
            Queue<int> queue2 = new Queue<int>(new[] { 1, 2 });

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.False);
        }

        [Test]
        public void TestQueueOfStringsEquality()
        {
            // Create two queues with identical strings
            Queue<string> queue1 = new Queue<string>(new[] { "one", "two", "three" });
            Queue<string> queue2 = new Queue<string>(new[] { "one", "two", "three" });

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.True);
        }

        [Test]
        public void TestQueueOfStringsInequality()
        {
            // Create two queues with different strings
            Queue<string> queue1 = new Queue<string>(new[] { "one", "two", "three" });
            Queue<string> queue2 = new Queue<string>(new[] { "three", "two", "one" });

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.False);
        }

        [Test]
        public void TestQueueOfStringsWithDifferentLengths()
        {
            // Create two queues with different lengths of strings
            Queue<string> queue1 = new Queue<string>(new[] { "one", "two", "three" });
            Queue<string> queue2 = new Queue<string>(new[] { "one", "two" });

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.False);
        }

        [Test]
        public void TestQueueOfPersonsEquality()
        {
            // Create two queues with identical Person objects
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

            Queue<Person> queue1 = new Queue<Person>();
            queue1.Enqueue(person1);

            Queue<Person> queue2 = new Queue<Person>();
            queue2.Enqueue(person2);

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.True);
        }

        [Test]
        public void TestQueueOfPersonsInequality()
        {
            // Create two queues with different Person objects
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

            Queue<Person> queue1 = new Queue<Person>();
            queue1.Enqueue(person1);

            Queue<Person> queue2 = new Queue<Person>();
            queue2.Enqueue(person2);

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.False);
        }

        [Test]
        public void TestQueueOfPersonsWithNullValues()
        {
            // Create two queues with Person objects containing null values
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

            Queue<Person> queue1 = new Queue<Person>();
            queue1.Enqueue(person1);

            Queue<Person> queue2 = new Queue<Person>();
            queue2.Enqueue(person2);

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.True);
        }

        [Test]
        public void TestQueueOfPersonsWithDifferentLengths()
        {
            // Create two queues with different lengths of Person objects
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

            Queue<Person> queue1 = new Queue<Person>();
            queue1.Enqueue(person1);

            Queue<Person> queue2 = new Queue<Person>();
            queue2.Enqueue(person2);
            queue2.Enqueue(person2); // Make queue2 longer

            Assert.That(_deepComparator.DeepEquals(queue1, queue2), Is.False);
        }
    }
}
