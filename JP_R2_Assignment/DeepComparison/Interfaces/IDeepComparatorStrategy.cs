namespace JP_R2_Assignment.DeepComparison.Interfaces
{
    /// <summary>
    /// Interface for deep comparison strategies.
    /// </summary>
    /// <typeparam name="T">The type of objects to compare.</typeparam>
    internal interface IDeepComparatorStrategy<T>
    {
        /// <summary>
        /// Determines whether two objects of type T are deeply equal.
        /// </summary>
        /// <param name="obj1">The first object to compare.</param>
        /// <param name="obj2">The second object to compare.</param>
        /// <param name="type">Optional. The type of objects being compared.</param>
        /// <returns><c>true</c> if the specified objects are deeply equal; otherwise, <c>false</c>.</returns>
        bool DeepEquals(T obj1, T obj2, Type? type = null);
    }
}
