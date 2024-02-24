using System.Collections.Generic;

namespace Balloonatics.Utils
{
    public static class Random
    {
        public static T GetRandomElement<T>(this T[] arr)
        {
            return arr[UnityEngine.Random.Range(0, arr.Length)];
        }

        public static T GetRandomElement<T>(this List<T> coll)
        {
            return coll[UnityEngine.Random.Range(0, coll.Count)];
        }
    }
}
