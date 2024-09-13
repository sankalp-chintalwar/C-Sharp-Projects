using JP_R2_Assignment.DeepComparison;
using JP_R2_Assignment.DeepComparison.CustomComparators;
using System.Collections;
using System.Text.Json.Serialization;

namespace JP_R2_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var deepComparator = new DeepComparator();

            // Only used when custom comparison logic is required.
            // Optional
            deepComparator.AddCustomStrategy(new IntegerComparator<int>(deepComparator));

            // Regular usage of deep comparator
            // deepComparator.DeepEquals(1, 1);

            Console.WriteLine($"Are ( 1 , 1 ) Equal: {deepComparator.DeepEquals(1, 1)}");
            Console.ReadKey();

            // Run Unit Tests to Check Deep Comparison for any type of objects
        }
    }

}
