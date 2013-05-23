using System;
using System.Collections.Generic;
using System.Linq;

namespace Jobney.Learning.ChainOfResponsibility.ExtensionMethods
{
    public static class EnumerableExtensions
    {
        //Function to get random number
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(max);
            }
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            T[] elements = source.ToArray();
            // Note i > 0 to avoid final pointless iteration
            for (int i = elements.Length - 1; i > 0; i--)
            {
                // Swap element "i" with a random earlier element it (or itself)
                int swapIndex = GetRandomNumber(i + 1);
                T tmp = elements[i];
                elements[i] = elements[swapIndex];
                elements[swapIndex] = tmp;
            }
            // Lazily yield (avoiding aliasing issues etc)
            foreach (T element in elements)
            {
                yield return element;
            }
        }
    }
}