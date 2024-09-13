using JP_R2_Assignment.DeepComparison.Interfaces;
using System;
using System.Reflection;

namespace JP_R2_Assignment.DeepComparison.Comparators
{
    /// <summary>
    /// Provides deep comparison for Queue<T> objects based on their elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the Queue.</typeparam>
    internal class QueueComparator<T> : IDeepComparatorStrategy<T>
    {
        private readonly DeepComparator _deepComparator;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueComparator{T}"/> class.
        /// </summary>
        /// <param name="deepComparator">The deep comparator used for recursive comparisons.</param>
        public QueueComparator(DeepComparator deepComparator)
        {
            _deepComparator = deepComparator;
        }

        /// <summary>
        /// Determines whether two Queue<T> objects are deeply equal by comparing their elements.
        /// </summary>
        /// <param name="queue1">The first Queue object to compare.</param>
        /// <param name="queue2">The second Queue object to compare.</param>
        /// <param name="type">The type of elements in the Queue.</param>
        /// <returns><c>true</c> if the specified Queue objects are deeply equal; otherwise, <c>false</c>.</returns>
        public bool DeepEquals(T queue1, T queue2, Type? type = null)
        {
            if (queue1 == null && queue2 == null)
                return true;
            if (queue1 == null || queue2 == null)
                return false;

            type = type ?? typeof(T);
            // Get the generic argument type of T (e.g., int, string)
            Type elementType = type.GetGenericArguments()[0] ?? typeof(object);

            // Use reflection to convert Queue<T> to arrays for comparison
            MethodInfo? toArrayMethod = typeof(Queue<>)
                .MakeGenericType(elementType)
                .GetMethod("ToArray");

            if (toArrayMethod == null)
                throw new Exception("Cannot find the 'ToArray' method for Queue<T>");

            Array? array1 = toArrayMethod.Invoke(queue1, null) as Array;
            Array? array2 = toArrayMethod.Invoke(queue2, null) as Array;

            if (array1 == null || array2 == null)
                throw new Exception("Failed to convert Queue<T> to arrays for comparison");

            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                object? element1 = array1.GetValue(i);
                object? element2 = array2.GetValue(i);

                if (!_deepComparator.DeepEquals(element1, element2, elementType))
                    return false;
            }

            return true;
        }
    }
}
