using JP_R2_Assignment.DeepComparison.Interfaces;
using System;

namespace JP_R2_Assignment.DeepComparison.Comparators
{
    /// <summary>
    /// Provides a generic equality comparator for comparing objects of type T.
    /// Used for direct equality comparison
    /// </summary>
    /// <typeparam name="T">The type of objects being compared. Examples include int, float, string, etc.</typeparam>
    internal class GenericEqualityComparator<T> : IDeepComparatorStrategy<T>
    {
        /// <summary>
        /// Determines whether two objects of type T are deeply equal by using the default equality comparison.
        /// </summary>
        /// <param name="obj1">The first object to compare.</param>
        /// <param name="obj2">The second object to compare.</param>
        /// <param name="type">The type of objects being compared.</param>
        /// <returns><c>true</c> if the specified objects are deeply equal; otherwise, <c>false</c>.</returns>
        public bool DeepEquals(T obj1, T obj2, Type? type = null)
        {
            if (obj1 == null && obj2 == null)
                return true;
            if (obj1 == null || obj2 == null)
                return false;

            return obj1.Equals(obj2);
        }
    }
}
