using JP_R2_Assignment.DeepComparison.Tests.Models;
using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class StructTypeTests
    {
        private DeepComparator _deepComparator;
        public StructTypeTests()
        {
            _deepComparator = new DeepComparator();

        }

        // Simple Struct
        [Test]
        public void TestSimpleStructEquality()
        {
            SimpleStruct a = new SimpleStruct { Value = 5 };
            SimpleStruct b = new SimpleStruct { Value = 5 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestSimpleStructInequality()
        {
            SimpleStruct a = new SimpleStruct { Value = 5 };
            SimpleStruct b = new SimpleStruct { Value = 10 };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        // Complex Struct
        [Test]
        public void TestComplexStructEquality()
        {
            ComplexStruct a = new ComplexStruct { Id = 1, Name = "John" };
            ComplexStruct b = new ComplexStruct { Id = 1, Name = "John" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.True);
        }

        [Test]
        public void TestComplexStructInequalityById()
        {
            ComplexStruct a = new ComplexStruct { Id = 1, Name = "John" };
            ComplexStruct b = new ComplexStruct { Id = 2, Name = "John" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        [Test]
        public void TestComplexStructInequalityByName()
        {
            ComplexStruct a = new ComplexStruct { Id = 1, Name = "John" };
            ComplexStruct b = new ComplexStruct { Id = 1, Name = "Jane" };
            Assert.That(_deepComparator.DeepEquals(a, b), Is.False);
        }

        // Struct with Reference Type Property
        [Test]
        public void TestPersonStructEquality()
        {
            Address address1 = new Address { Street = "123 Main St", City = "Anytown" };
            Address address2 = new Address { Street = "123 Main St", City = "Anytown" };

            Person person1 = new Person { Name = "John", Age = 30, Residence = address1 };
            Person person2 = new Person { Name = "John", Age = 30, Residence = address2 };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.True);
        }

        [Test]
        public void TestPersonStructInequalityByName()
        {
            Address address1 = new Address { Street = "123 Main St", City = "Anytown" };
            Address address2 = new Address { Street = "123 Main St", City = "Anytown" };

            Person person1 = new Person { Name = "John", Age = 30, Residence = address1 };
            Person person2 = new Person { Name = "Jane", Age = 30, Residence = address2 };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.False);
        }

        [Test]
        public void TestPersonStructInequalityByResidence()
        {
            Address address1 = new Address { Street = "123 Main St", City = "Anytown" };
            Address address2 = new Address { Street = "456 Elm St", City = "Othertown" };

            Person person1 = new Person { Name = "John", Age = 30, Residence = address1 };
            Person person2 = new Person { Name = "John", Age = 30, Residence = address2 };

            Assert.That(_deepComparator.DeepEquals(person1, person2), Is.False);
        }
    }
}
