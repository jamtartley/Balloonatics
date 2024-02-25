using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Balloonatics.Utils
{
    public static class RandomExtensions
    {
        public static T GetRandomElement<T>(this T[] arr)
        {
            return arr[Random.Range(0, arr.Length)];
        }

        public static T GetRandomElement<T>(this List<T> coll)
        {
            return coll[Random.Range(0, coll.Count)];
        }

        public static IEnumerable<T> GetRandomSelection<T>(this IEnumerable<T> list, float ratio = 1f)
        {
            int size = list.Count();
            int toTake = (int)(size * Mathf.Clamp01(ratio));

            return list.OrderBy(x => Random.Range(0f, 1f)).Take(toTake);
        }
    }
}
