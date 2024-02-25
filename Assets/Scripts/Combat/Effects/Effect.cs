using Balloonatics.Player;
using UnityEngine;

namespace Balloonatics.Combat
{
    public abstract class Effect : MonoBehaviour
    {
        [HideInInspector] protected PlayerController Player;

        private bool isUsed;

        public abstract bool MaybeApplyOn(GameObject target);

        private void Start()
        {
            Player = GetComponent<Projectile>().Weapon.PlayerController;
        }

        public void Use(GameObject target)
        {
            if (isUsed) return;

            isUsed |= MaybeApplyOn(target);
        }
    }
}
