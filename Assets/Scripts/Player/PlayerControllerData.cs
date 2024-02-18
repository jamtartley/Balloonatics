using System.Collections.Generic;
using UnityEngine;

namespace Balloonatics.Player
{
    [CreateAssetMenu(menuName = "Custom/Player/PlayerControllerData")]
    public class PlayerControllerData : ScriptableObject
    {
        public int InitialBalloons;
    }
}

