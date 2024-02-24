using UnityEngine;

namespace Balloonatics.Combat
{
    [CreateAssetMenu(menuName = "Custom/Combat/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        public int Capacity;
        public int ShotsPerSecond;
        public int AmmoPerShot;

        public Projectile ProjectilePrefab;
        public float ReleaseForce;
        public float RecoilForce;
    }
}

