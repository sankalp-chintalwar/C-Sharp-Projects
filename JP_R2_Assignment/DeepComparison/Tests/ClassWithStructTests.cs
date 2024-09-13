using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    public class ClassWithStructTests
    {
        private DeepComparator _deepComparator;

        public ClassWithStructTests()
        {
            _deepComparator = new DeepComparator();
        }

        [Test]
        public void TestPersonEquality()
        {
            // Create two instances of Person with identical data
            var person1 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" }
            };

            var person2 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" }
            };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.True);
        }

        [Test]
        public void TestPersonInequality()
        {
            // Create two instances of Person with different data
            var person1 = new Person
            {
                Name = "Alice",
                Age = 30,
                Residence = new Address { Street = "123 Main St", City = "Anytown" }
            };

            var person2 = new Person
            {
                Name = "Bob",
                Age = 25,
                Residence = new Address { Street = "456 Oak Ave", City = "Othertown" }
            };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.False);
        }
    }
}
