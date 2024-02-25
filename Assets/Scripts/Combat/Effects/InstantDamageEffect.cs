using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Combat
{
    public class InstantDamageEffect : Effect
    {
        public float Damage;

        public override bool MaybeApplyOn(GameObject target)
        {
            var health = target.GetFirstUpHierarchy<Health>();
            if (!health) return false;

            health.TakeDamage(Damage, transform.position.ToVector2(), Player);
            return true;
        }
    }
}
