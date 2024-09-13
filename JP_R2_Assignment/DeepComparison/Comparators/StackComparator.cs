using JP_R2_Assignment.DeepComparison.Interfaces;
using System;
using System.Reflection;

namespace JP_R2_Assignment.DeepComparison.CustomComparators
{
    /// <summary>
    /// Provides deep comparison for Stack<T> objects based on their elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the Stack.</typeparam>
    internal class StackComparator<T> : IDeepComparatorStrategy<T>
    {
        private readonly DeepComparator _deepComparator;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackComparator{T}"/> class.
        /// </summary>
        /// <param name="deepComparator">The deep comparator used for recursive comparisons.</param>
        public StackComparator(DeepComparator deepComparator)
        {
            _deepComparator = deepComparator;
        }

        /// <summary>
        /// Determines whether two Stack<T> objects are deeply equal by comparing their elements.
        /// </summary>
        /// <param name="stack1">The first Stack object to compare.</param>
        /// <param name="stack2">The second Stack object to compare.</param>
        /// <param name="type">The type of elements in the Stack.</param>
        /// <returns><c>true</c> if the specified Stack objects are deeply equal; otherwise, <c>false</c>.</returns>
        public bool DeepEquals(T stack1, T stack2, Type? type = null)
        {
            if (stack1 == null && stack2 == null)
                return true;
            if (stack1 == null || stack2 == null)
                return false;

            type = type?? typeof(T);
            // Get the generic argument type of T (e.g., int, string)
            Type elementType = type.GetGenericArguments()[0] ?? typeof(object);

            // Use reflection to convert Stack<T> to arrays for comparison
            MethodInfo? toArrayMethod = typeof(Stack<>)
                .MakeGenericType(elementType)
                .GetMethod("ToArray");

            if (toArrayMethod == null)
                throw new Exception("Cannot find the 'ToArray' method for Stack<T>");

            Array? array1 = toArrayMethod.Invoke(stack1, null) as Array;
            Array? array2 = toArrayMethod.Invoke(stack2, null) as Array;

            if (array1 == null || array2 == null)
                throw new Exception("Failed to convert Stack<T> to arrays for comparison");

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
