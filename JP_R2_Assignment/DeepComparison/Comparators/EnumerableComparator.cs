using JP_R2_Assignment.DeepComparison.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace JP_R2_Assignment.DeepComparison.Comparators
{
    /// <summary>
    /// Provides deep comparison for enumerable types.
    /// </summary>
    /// <typeparam name="T">The type of the objects being compared. IList, etc. which are derived from IEnumerable</typeparam>
    internal class EnumerableComparator<T> : IDeepComparatorStrategy<T>
    {
        private readonly DeepComparator _deepComparator;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableComparator{T}"/> class.
        /// </summary>
        /// <param name="deepComparator">The deep comparator used for recursive comparisons.</param>
        public EnumerableComparator(DeepComparator deepComparator)
        {
            _deepComparator = deepComparator;
        }

        /// <summary>
        /// Determines whether two enumerable objects are deeply equal.
        /// </summary>
        /// <param name="obj1">The first object to compare.</param>
        /// <param name="obj2">The second object to compare.</param>
        /// <param name="type">The type of elements within the enumerable.</param>
        /// <returns><c>true</c> if the specified objects are deeply equal; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException">Thrown when objects are not of enumerable type.</exception>
        public bool DeepEquals(T obj1, T obj2, Type? type = null)
        {
            if (obj1 == null && obj2 == null)
                return true;
            if (obj1 == null || obj2 == null)
                return false;

            if (obj1 is IEnumerable enumerable1 && obj2 is IEnumerable enumerable2)
            {
                var list1 = ToList(enumerable1.GetEnumerator());
                var list2 = ToList(enumerable2.GetEnumerator());

                if (list1.Count != list2.Count)
                    return false;

                type = type ?? typeof(T);

                var matchedIndices = new HashSet<int>();
                foreach (var item1 in list1)
                {
                    Type? item1Type = item1?.GetType();
                    bool matchFound = false;
                    for (int j = 0; j < list2.Count; j++)
                    {
                        if (matchedIndices.Contains(j)) continue;

                        Type? item2Type = list2[j]?.GetType();
                        if (item1Type == item2Type && _deepComparator.DeepEquals(item1, list2[j], item1Type))
                        {
                            matchedIndices.Add(j);
                            matchFound = true;
                            break;
                        }
                    }

                    if (!matchFound)
                    {
                        return false;
                    }
                }

                return matchedIndices.Count == list2.Count;
            }

            throw new ArgumentException("Objects must be of enumerable type");
        }

        /// <summary>
        /// Converts an enumerator to a list of objects.
        /// </summary>
        /// <param name="enumerator">The enumerator to convert.</param>
        /// <returns>A list of objects contained in the enumerator.</returns>
        private List<object> ToList(IEnumerator enumerator)
        {
            var list = new List<object>();
            while (enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }
            return list;
        }
    }
}
