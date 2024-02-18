using System.Collections.Generic;
using UnityEngine;

namespace Balloonatics.Game
{
    [CreateAssetMenu(menuName = "Custom/Game/BalloonData")]
    public class BalloonData : ScriptableObject
    {
        public RangeValue Force;
        public RangeValue Sections;

        public List<Color> Colours;
    }
}

