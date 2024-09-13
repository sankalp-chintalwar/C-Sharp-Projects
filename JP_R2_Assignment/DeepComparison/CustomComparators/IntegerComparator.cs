using JP_R2_Assignment.DeepComparison.Interfaces;
using System;

namespace JP_R2_Assignment.DeepComparison.CustomComparators
{
    /// <summary>
    /// Provides deep comparison for integer values.
    /// Example custom comparator
    /// </summary>
    /// <typeparam name="T">The type of objects being compared (should be int).</typeparam>
    internal class IntegerComparator<T> : IDeepComparatorStrategy<T>
    {
        private readonly DeepComparator _deepComparator;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerComparator{T}"/> class.
        /// </summary>
        /// <param name="deepComparator">The deep comparator used for recursive comparisons.</param>
        public IntegerComparator(DeepComparator deepComparator)
        {
            _deepComparator = deepComparator;
        }

        /// <summary>
        /// Determines whether two integer values are deeply equal.
        /// </summary>
        /// <param name="obj1">The first integer to compare.</param>
        /// <param name="obj2">The second integer to compare.</param>
        /// <param name="type">The type of objects being compared (should be int).</param>
        /// <returns><c>true</c> if the specified integers are deeply equal; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when the type of objects being compared is not integer.</exception>
        public bool DeepEquals(T obj1, T obj2, Type? type = null)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null || obj2 == null)
                return false;

            if (obj1 is int i1 && obj2 is int i2)
            {
                return i1 == i2;
            }

            throw new ArgumentException("Type must be integer!");
        }
    }
}
