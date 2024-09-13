using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;
using System.Collections.Generic;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class ClassTypeTests
    {
        private DeepComparator _deepComparator;
        public ClassTypeTests()
        {
            _deepComparator = new DeepComparator();
        }

        // Simple test for two equal Person objects
        [Test]
        public void TestSimpleObjectsEquality()
        {
            var address = new Address { Street = "123 Main St", City = "Anytown" };
            var person1 = new Person { Name = "John Doe", Age = 30, Residence = address };
            var person2 = new Person { Name = "John Doe", Age = 30, Residence = address };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.True);
        }

        // Simple test for two different Person objects
        [Test]
        public void TestSimpleObjectsInequality()
        {
            var address1 = new Address { Street = "123 Main St", City = "Anytown" };
            var address2 = new Address { Street = "456 Oak Ave", City = "Othertown" };
            var person1 = new Person { Name = "John Doe", Age = 30, Residence = address1 };
            var person2 = new Person { Name = "Jane Smith", Age = 25, Residence = address2 };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.False);
        }

        // Complex test for two equal Person objects with nested objects and lists
        [Test]
        public void TestComplexObjectsEquality()
        {
            var address = new Address { Street = "123 Main St", City = "Anytown" };
            var phone1 = new PhoneNumber { Type = "Home", Number = "555-1234" };
            var phone2 = new PhoneNumber { Type = "Mobile", Number = "555-5678" };
            var person1 = new Person
            {
                Name = "John Doe",
                Age = 30,
                Residence = address,
                PhoneNumbers = new List<PhoneNumber> { phone1, phone2 }
            };
            var person2 = new Person
            {
                Name = "John Doe",
                Age = 30,
                Residence = address,
                PhoneNumbers = new List<PhoneNumber> { phone2, phone1 }
            };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.True);
        }

        // Complex test for two different Person objects with nested objects and lists
        [Test]
        public void TestComplexObjectsInequality()
        {
            var address1 = new Address { Street = "123 Main St", City = "Anytown" };
            var address2 = new Address { Street = "456 Oak Ave", City = "Othertown" };
            var phone1 = new PhoneNumber { Type = "Home", Number = "555-1234" };
            var phone2 = new PhoneNumber { Type = "Mobile", Number = "555-5678" };
            var person1 = new Person
            {
                Name = "John Doe",
                Age = 30,
                Residence = address1,
                PhoneNumbers = new List<PhoneNumber> { phone1 }
            };
            var person2 = new Person
            {
                Name = "Jane Smith",
                Age = 25,
                Residence = address2,
                PhoneNumbers = new List<PhoneNumber> { phone2 }
            };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.False);
        }
    }
}
