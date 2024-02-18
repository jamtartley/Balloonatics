using UnityEngine;

namespace Balloonatics.Player
{
    [CreateAssetMenu(menuName = "Custom/Player/MovementData")]
    public class PlayerMovementData : ScriptableObject
    {
        public float HorizontalSpeed;
        public float VerticalUpSpeed;
        public float VerticalDownSpeed;
    }
}

