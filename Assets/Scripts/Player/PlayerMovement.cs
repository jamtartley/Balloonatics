using UnityEngine;

namespace Balloonatics.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerMovement : MonoBehaviour
    {
        public PlayerMovementData Data;

        [SerializeField] private Rigidbody2D body;

        private PlayerController controller;
        private bool canMove;

        private void Awake()
        {
            controller = GetComponent<PlayerController>();
            canMove = true;
        }

        public void Move(Vector2 dir)
        {
            if (canMove == false || dir == Vector2.zero) return;

            float horizontalMovement = dir.x * Data.HorizontalSpeed;
            float verticalMovement = dir.y * (dir.y < 0 ? Data.VerticalDownSpeed : Data.VerticalUpSpeed);

            body.AddForce(new Vector2(horizontalMovement, verticalMovement), ForceMode2D.Force);
        }

        public void Recoil(Vector2 dir)
        {
            // @FEATURE: add recoil
        }
    }
}
