using JP_R2_Assignment.DeepComparison.Comparators;
using JP_R2_Assignment.DeepComparison.CustomComparators;
using JP_R2_Assignment.DeepComparison.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace JP_R2_Assignment.DeepComparison
{
    /// <summary>
    /// Provides deep comparison functionality for various types of objects.
    /// </summary>
    internal class DeepComparator
    {
        private readonly Dictionary<Type, object> _strategies;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeepComparator"/> class.
        /// </summary>
        public DeepComparator()
        {
            _strategies = new Dictionary<Type, object>();
        }

        /// <summary>
        /// Adds a custom comparison strategy for a specific type.
        /// </summary>
        /// <typeparam name="T">The type of objects for which the strategy is added.</typeparam>
        /// <param name="strategy">The custom comparison strategy.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="type"/> or <paramref name="strategy"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when a strategy for the specified type already exists.</exception>
        public void AddCustomStrategy<T>(IDeepComparatorStrategy<T> strategy)
        {
            var type = typeof(T);
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (strategy == null)
                throw new ArgumentNullException(nameof(strategy));

            if (_strategies.ContainsKey(type))
            {
                throw new InvalidOperationException($"Strategy for type {type} already exists.");
            }
            _strategies.Add(type, strategy);
        }

        /// <summary>
        /// Determines whether two objects of type T are deeply equal.
        /// </summary>
        /// <typeparam name="T">The type of objects to compare.</typeparam>
        /// <param name="obj1">The first object to compare.</param>
        /// <param name="obj2">The second object to compare.</param>
        /// <param name="type">Optional. The type of objects being compared.</param>
        /// <returns><c>true</c> if the specified objects are deeply equal; otherwise, <c>false</c>.</returns>
        public bool DeepEquals<T>(T obj1, T obj2, Type? type = null)
        {
            if (obj1 == null && obj2 == null)
                return true;
            else if (obj1 == null || obj2 == null)
                return false;

            type ??= typeof(T);

            if (_strategies.TryGetValue(type, out var strategy) && strategy is IDeepComparatorStrategy<T> typedStrategy)
            {
                return typedStrategy.DeepEquals(obj1, obj2, type);
            }

            if (IsPrimitiveOrDecimal(type))
            {
                return new GenericEqualityComparator<T>().DeepEquals(obj1, obj2);
            }
            else if (IsValueType(type))
            {
                if (IsEnumOrNullable(type))
                {
                    return new GenericEqualityComparator<T>().DeepEquals(obj1, obj2, type);
                }
                else
                {
                    return new ObjectComparator<T>(this).DeepEquals(obj1, obj2, type);
                }
            }
            else
            {
                return HandleReferenceTypeComparison(obj1, obj2, type);
            }
        }

        private static bool IsPrimitiveOrDecimal(Type type)
        {
            return type.IsPrimitive || type == typeof(decimal);
        }

        private static bool IsValueType(Type type)
        {
            return type.IsValueType && !type.IsPrimitive && type != typeof(decimal);
        }

        private static bool IsEnumOrNullable(Type type)
        {
            return type.IsEnum || Nullable.GetUnderlyingType(type) != null;
        }

        private bool HandleReferenceTypeComparison<T>(T obj1, T obj2, Type type)
        {
            if (type == typeof(string))
            {
                return new GenericEqualityComparator<T>().DeepEquals(obj1, obj2, type);
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                return new KeyValuePairComparator<T>(this).DeepEquals(obj1, obj2, type);
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Stack<>))
            {
                return new StackComparator<T>(this).DeepEquals(obj1, obj2, type);
            }
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Queue<>))
            {
                return new QueueComparator<T>(this).DeepEquals(obj1, obj2, type);
            }
            else if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                return new EnumerableComparator<T>(this).DeepEquals(obj1, obj2, type);
            }
            else if (type.IsClass)
            {
                return new ObjectComparator<T>(this).DeepEquals(obj1, obj2, type);
            }

            throw new NotSupportedException($"No comparator found for type {type}");
        }
    }
}
