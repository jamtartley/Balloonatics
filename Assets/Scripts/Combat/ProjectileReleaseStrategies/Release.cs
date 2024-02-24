using UnityEngine;

namespace Balloonatics.Combat
{
    [RequireComponent(typeof(Weapon))]
    public abstract class Release : MonoBehaviour
    {
        protected Weapon Weapon;

        private void Awake()
        {
            Weapon = GetComponent<Weapon>();
        }

        public abstract void Shoot(Vector2 direction, Quaternion quaternion);
    }
}
