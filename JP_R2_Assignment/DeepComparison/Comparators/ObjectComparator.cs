using JP_R2_Assignment.DeepComparison.Interfaces;
using System;
using System.Reflection;

namespace JP_R2_Assignment.DeepComparison.Comparators
{
    /// <summary>
    /// Provides deep comparison for objects of type T based on their fields and properties.
    /// </summary>
    /// <typeparam name="T">The type of objects being compared.</typeparam>
    internal class ObjectComparator<T> : IDeepComparatorStrategy<T>
    {
        private readonly DeepComparator _deepComparator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectComparator{T}"/> class.
        /// </summary>
        /// <param name="deepComparator">The deep comparator used for recursive comparisons.</param>
        public ObjectComparator(DeepComparator deepComparator)
        {
            _deepComparator = deepComparator;
        }

        /// <summary>
        /// Determines whether two objects of type T are deeply equal by comparing their fields and properties.
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

            type = type == null ? typeof(T) : type;

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var processedProperties = new HashSet<string>();

            foreach (var property in properties)
            {
                var value1 = property.GetValue(obj1);
                var value2 = property.GetValue(obj2);

                processedProperties.Add(property.Name);

                if (!_deepComparator.DeepEquals(value1, value2, property.PropertyType))
                    return false;
            }

            foreach (var field in fields)
            {
                if (processedProperties.Contains(field.Name))
                    continue;

                var value1 = field.GetValue(obj1);
                var value2 = field.GetValue(obj2);

                if (!_deepComparator.DeepEquals(value1, value2, field.FieldType))
                    return false;
            }

            return true;
        }
    }
}
