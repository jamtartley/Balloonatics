using UnityEngine;

namespace Balloonatics.Combat
{
    public class SingleRelease : Release
    {
        public override void Shoot(Vector2 direction, Quaternion quaternion)
        {
            Projectile proj = Instantiate(Weapon.Data.ProjectilePrefab, Weapon.SpawnPoint.position, quaternion, null);
            proj.Weapon = Weapon;
            proj.Body.AddForceAtPosition(direction * Weapon.Data.ReleaseForce, Weapon.SpawnPoint.position, ForceMode2D.Impulse);
        }
    }
}
