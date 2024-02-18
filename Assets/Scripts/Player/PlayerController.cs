using UnityEngine;

namespace Balloonatics.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public PlayerInput Input;
        [HideInInspector] public PlayerMovement Movement;

        private void Start()
        {
            Input = GetComponent<PlayerInput>();
            Movement = GetComponent<PlayerMovement>();
        }
    }
}
