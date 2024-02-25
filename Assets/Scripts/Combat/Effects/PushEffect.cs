using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Combat
{
    public class PushEffect : Effect
    {
        public float PushForce;

        public override bool MaybeApplyOn(GameObject target)
        {
            var body = target.GetFirstUpHierarchy<Rigidbody2D>();

            if (!body)
            {
                return false;
            }

            body.AddForce(Projectile.Body.velocity.normalized * PushForce, ForceMode2D.Impulse);

            return true;
        }
    }
}
