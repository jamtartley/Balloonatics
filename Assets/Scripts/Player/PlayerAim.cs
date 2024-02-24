using Balloonatics.Combat;
using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Player
{
    public class PlayerAim : MonoBehaviour
    {
        [HideInInspector] public AimPositionData AimPosition;

        [SerializeField] private Rigidbody2D armRoot;
        [SerializeField] private Rigidbody2D[] armBodies;
        [SerializeField] private HingeJoint2D armJoint;

        private PlayerController controller;
        private Vector2 prevAimPos;
        private Weapon weapon => controller.Weapon;

        public enum AimInputType
        {
            NORMALISED,
            WORLD
        }

        public struct AimPositionData
        {
            public AimInputType Type;
            public Vector2 World;
            public Vector2 Normalised;
        }

        private void Awake()
        {
            controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition).ToVector2();
            UpdateAim(vec, AimInputType.WORLD);

            HandleArmJointAndBodyBehaviour();
        }

        private void HandleArmJointAndBodyBehaviour()
        {
            foreach (var armBody in armBodies)
            {
                armBody.mass = weapon == null ? 1f : 0.1f;
                armBody.drag = weapon == null ? 0.2f : 15f;
            }

            armJoint.useLimits = weapon != null;
        }

        private void UpdateAim(Vector2 aimPos, AimInputType type)
        {
            if (aimPos == Vector2.zero) return;
            if (weapon == null) return;

            Vector2 spawn2d = controller.Weapon.SpawnPoint.position.ToVector2();
            aimPos = Vector2.Lerp(prevAimPos, aimPos, 10 * Time.deltaTime);
            prevAimPos = aimPos;

            AimPosition.Type = type;
            AimPosition.World = type == AimInputType.WORLD ? aimPos : spawn2d + (aimPos * 10000);
            AimPosition.Normalised = type == AimInputType.NORMALISED ? aimPos : (aimPos - spawn2d).normalized;

            var dir = AimPosition.World - spawn2d;
            var ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 90;
            armRoot.MoveRotation(ang);
        }
    }
}
