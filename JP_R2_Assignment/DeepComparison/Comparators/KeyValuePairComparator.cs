using JP_R2_Assignment.DeepComparison.Interfaces;
using System;
using System.Reflection;

namespace JP_R2_Assignment.DeepComparison.Comparators
{
    /// <summary>
    /// Provides deep comparison for KeyValuePair<TKey, TValue> objects.
    /// </summary>
    /// <typeparam name="T">The type of KeyValuePair being compared.</typeparam>
    internal class KeyValuePairComparator<T> : IDeepComparatorStrategy<T>
    {
        private readonly DeepComparator _deepComparator;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePairComparator{T}"/> class.
        /// </summary>
        /// <param name="deepComparator">The deep comparator used for recursive comparisons.</param>
        public KeyValuePairComparator(DeepComparator deepComparator)
        {
            _deepComparator = deepComparator;
        }

        /// <summary>
        /// Determines whether two KeyValuePair<TKey, TValue> objects are deeply equal.
        /// </summary>
        /// <param name="obj1">The first KeyValuePair object to compare.</param>
        /// <param name="obj2">The second KeyValuePair object to compare.</param>
        /// <param name="type">The type of KeyValuePair being compared.</param>
        /// <returns><c>true</c> if the specified KeyValuePair objects are deeply equal; otherwise, <c>false</c>.</returns>
        public bool DeepEquals(T obj1, T obj2, Type? type = null)
        {
            if (obj1 == null && obj2 == null)
                return true;
            if (obj1 == null || obj2 == null)
                return false;

            type = type ?? typeof(T);
            Type keyType = type.GetGenericArguments()[0] ?? typeof(object);
            Type valueType = type.GetGenericArguments()[1] ?? typeof(object);

            // Get Key and Value properties dynamically
            PropertyInfo? keyProperty = type.GetProperty("Key");
            PropertyInfo? valueProperty = type.GetProperty("Value");

            if (keyProperty == null || valueProperty == null)
                throw new InvalidOperationException("Type T must be a KeyValuePair<TKey, TValue>");

            // Get Key and Value values from obj1 and obj2
            object? key1 = keyProperty.GetValue(obj1);
            object? key2 = keyProperty.GetValue(obj2);
            object? value1 = valueProperty.GetValue(obj1);
            object? value2 = valueProperty.GetValue(obj2);

            if (!_deepComparator.DeepEquals(key1, key2, keyType))
                return false;

            if (!_deepComparator.DeepEquals(value1, value2, valueType))
                return false;

            return true;
        }
    }
}
