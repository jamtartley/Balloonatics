using UnityEngine;

namespace Balloonatics.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [HideInInspector] public Weapon Weapon;
        [HideInInspector] public Rigidbody2D Body;

        private void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
        }
    }
}
