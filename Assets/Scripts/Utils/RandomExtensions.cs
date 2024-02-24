using System.Collections.Generic;
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
    }
}
