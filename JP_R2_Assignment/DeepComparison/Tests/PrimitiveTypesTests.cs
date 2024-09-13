using NUnit.Framework;

namespace JP_R2_Assignment.DeepComparison.Tests
{
    [TestFixture]
    internal class PrimitiveTypesTests
    {
        private readonly DeepComparator _deepComparator;
        public PrimitiveTypesTests()
        {
            _deepComparator = new DeepComparator();
            
        }

        // Integral Types
        [Test]
        public void TestByteEquality()
        {
            Assert.That(_deepComparator.DeepEquals((byte)5, (byte)5), Is.True);
        }

        [Test]
        public void TestByteInequality()
        {
            Assert.That(_deepComparator.DeepEquals((byte)5, (byte)10), Is.False);
        }

        [Test]
        public void TestSByteEquality()
        {
            Assert.That(_deepComparator.DeepEquals((sbyte)5, (sbyte)5), Is.True);
        }

        [Test]
        public void TestSByteInequality()
        {
            Assert.That(_deepComparator.DeepEquals((sbyte)5, (sbyte)10), Is.False);
        }

        [Test]
        public void TestShortEquality()
        {
            Assert.That(_deepComparator.DeepEquals((short)5, (short)5), Is.True);
        }

        [Test]
        public void TestShortInequality()
        {
            Assert.That(_deepComparator.DeepEquals((short)5, (short)10), Is.False);
        }

        [Test]
        public void TestUShortEquality()
        {
            Assert.That(_deepComparator.DeepEquals((ushort)5, (ushort)5), Is.True);
        }

        [Test]
        public void TestUShortInequality()
        {
            Assert.That(_deepComparator.DeepEquals((ushort)5, (ushort)10), Is.False);
        }

        [Test]
        public void TestIntEquality()
        {
            Assert.That(_deepComparator.DeepEquals(5, 5), Is.True);
        }

        [Test]
        public void TestIntInequality()
        {
            Assert.That(_deepComparator.DeepEquals(5, 10), Is.False);
        }

        [Test]
        public void TestUIntEquality()
        {
            Assert.That(_deepComparator.DeepEquals((uint)5, (uint)5), Is.True);
        }

        [Test]
        public void TestUIntInequality()
        {
            Assert.That(_deepComparator.DeepEquals((uint)5, (uint)10), Is.False);
        }

        [Test]
        public void TestLongEquality()
        {
            Assert.That(_deepComparator.DeepEquals((long)5, (long)5), Is.True);
        }

        [Test]
        public void TestLongInequality()
        {
            Assert.That(_deepComparator.DeepEquals((long)5, (long)10), Is.False);
        }

        [Test]
        public void TestULongEquality()
        {
            Assert.That(_deepComparator.DeepEquals((ulong)5, (ulong)5), Is.True);
        }

        [Test]
        public void TestULongInequality()
        {
            Assert.That(_deepComparator.DeepEquals((ulong)5, (ulong)10), Is.False);
        }

        // Floating-Point Types
        [Test]
        public void TestFloatEquality()
        {
            Assert.That(_deepComparator.DeepEquals(5.0f, 5.0f), Is.True);
        }

        [Test]
        public void TestFloatInequality()
        {
            Assert.That(_deepComparator.DeepEquals(5.0f, 10.0f), Is.False);
        }

        [Test]
        public void TestDoubleEquality()
        {
            Assert.That(_deepComparator.DeepEquals(5.0, 5.0), Is.True);
        }

        [Test]
        public void TestDoubleInequality()
        {
            Assert.That(_deepComparator.DeepEquals(5.0, 10.0), Is.False);
        }

        // Other Primitive Types
        [Test]
        public void TestCharEquality()
        {
            Assert.That(_deepComparator.DeepEquals('a', 'a'), Is.True);
        }

        [Test]
        public void TestCharInequality()
        {
            Assert.That(_deepComparator.DeepEquals('a', 'b'), Is.False);
        }

        [Test]
        public void TestBoolEquality()
        {
            Assert.That(_deepComparator.DeepEquals(true, true), Is.True);
        }

        [Test]
        public void TestBoolInequality()
        {
            Assert.That(_deepComparator.DeepEquals(true, false), Is.False);
        }
    }
}
