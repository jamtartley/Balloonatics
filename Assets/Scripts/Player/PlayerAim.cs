using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Player
{
    public class PlayerAim : MonoBehaviour
    {
        [HideInInspector] public AimPositionData AimPosition;

        [SerializeField] private Rigidbody2D armRoot;
        [SerializeField] private Transform spawnPoint;

        private Vector2 prevAimPos;

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

        private void Update()
        {
            Vector2 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition).ToVector2();
            UpdateAim(vec, AimInputType.WORLD);
        }

        private void UpdateAim(Vector2 aimPos, AimInputType type)
        {
            if (aimPos == Vector2.zero) return;

            Vector2 spawn2d = spawnPoint.position.ToVector2();
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
