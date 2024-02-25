using Balloonatics.Player;
using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Combat
{
    public class Weapon : MonoBehaviour
    {
        public WeaponData Data;
        [HideInInspector] public PlayerController PlayerController;

        [Space]
        public Transform SpawnPoint;

        [Space]
        private Release weaponRelease;
        private int bullets;
        private float secsUntilNextAllowed;

        private void Awake()
        {
            weaponRelease = GetComponent<Release>();
            bullets = Data.Capacity;

            PlayerController = gameObject.GetFirstUpHierarchy<PlayerController>();
            // @REFACTOR Assigning PlayerController weapon should not happen here
            PlayerController.Weapon = this;
        }

        private void Update()
        {
            if (secsUntilNextAllowed > 0) secsUntilNextAllowed -= Time.deltaTime;
        }

        public void Throw()
        {
            // @FEATURE Throwing weapons
            PlayerController.Weapon = null;
            Destroy(gameObject);
        }

        public void Shoot()
        {
            if (secsUntilNextAllowed > 0) return;
            if (bullets < Data.AmmoPerShot) return;

            secsUntilNextAllowed = 1f / Data.ShotsPerSecond;

            float angleRad = PlayerController.Aim.AimPosition.Normalised.ToAngle();
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
            Quaternion aimQuat = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);

            weaponRelease.Shoot(direction, aimQuat);

            PlayerController.Movement.Recoil(direction.normalized * Data.RecoilForce);

            bullets -= Data.AmmoPerShot;
            if (bullets < Data.AmmoPerShot) Throw();
        }
    }
}

