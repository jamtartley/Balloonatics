using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Combat
{
    public class SpreadRelease : Release
    {
        public SpreadReleaseData Data;

        private float GetEvenDistribution(float min, float max, int currentIteration, int iterationCount)
        {
            float chunk = Mathf.Abs(min - max) / (iterationCount - 1 == 0 ? 1 : iterationCount - 1);
            return min + (currentIteration * chunk);
        }

        public override void Shoot(Vector2 direction, Quaternion quaternion)
        {
            for (int i = 0; i < Data.ShotsPerRelease; i++)
            {
                Projectile proj = Instantiate(Weapon.Data.ProjectilePrefab, Weapon.SpawnPoint.position, quaternion, null);
                float angleMod = GetEvenDistribution(Data.Angle.Min, Data.Angle.Max, i, Data.ShotsPerRelease);
                float fireAngle = (direction.ToAngle() * Mathf.Rad2Deg + angleMod) * Mathf.Deg2Rad;
                Vector2 dir = new Vector2(direction.x + Mathf.Cos(fireAngle), direction.y + Mathf.Sin(fireAngle)).normalized;
                Vector2 force = dir * Weapon.Data.ReleaseForce * Random.Range(Data.MinForceModifier, 1f);

                proj.Weapon = Weapon;
                proj.Body.AddForceAtPosition(force, Weapon.SpawnPoint.position, ForceMode2D.Impulse);
            }
        }
    }
}
