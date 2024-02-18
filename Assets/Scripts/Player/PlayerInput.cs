using UnityEngine;

namespace Balloonatics.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerController controller;

        private void Awake()
        {
            controller = GetComponent<PlayerController>();
        }

        private void Update()
        {
            float x = 0;
            float y = 0;

            if (Input.GetKey(KeyCode.A)) x -= 1;
            if (Input.GetKey(KeyCode.D)) x += 1;

            if (Input.GetKey(KeyCode.S)) y -= 1;
            if (Input.GetKey(KeyCode.W)) y += 1;

            controller.Movement.Move(new Vector2(x, y));
        }
    }
}
