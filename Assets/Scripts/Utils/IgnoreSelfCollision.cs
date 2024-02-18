using UnityEngine;

namespace Balloonatics.Utils
{
    public class IgnoreSelfCollision : MonoBehaviour
    {
        private void Start()
        {
            Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();

            for (int i = 0; i < colliders.Length; i++)
            {
                for (int j = i + 1; j < colliders.Length; j++)
                {
                    Physics2D.IgnoreCollision(colliders[i], colliders[j]);
                }
            }
        }
    }
}
