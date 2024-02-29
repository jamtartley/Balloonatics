using Balloonatics.Game;
using Balloonatics.Player;
using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Combat
{
    public abstract class Effect : MonoBehaviour
    {
        [HideInInspector] protected PlayerController Player;
        [HideInInspector] protected Projectile Projectile;

        private bool isUsed;

        public abstract bool MaybeApplyOn(GameObject target);

        private void Start()
        {
            Projectile = GetComponent<Projectile>();
            Player = Projectile.Weapon.PlayerController;
        }

        public void Use(GameObject target)
        {
            if (isUsed) return;
            if (target.GetFirstUpHierarchy<PlayerController>() == Player) return;

            isUsed |= MaybeApplyOn(target);
        }
    }
}
