using UnityEngine;

namespace Balloonatics.Utils
{
    public static class VectorExtensions
    {
        public static Vector2 ToVector2(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 ToVector3(this Vector2 vector)
        {
            return new Vector3(vector.x, vector.y, 0);
        }

        public static float ToAngle(this Vector2 vec)
        {
            return (float)Mathf.Atan2(vec.y, vec.x);
        }
    }
}
