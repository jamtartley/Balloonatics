using UnityEngine;

namespace Balloonatics.Combat
{
    [CreateAssetMenu(menuName = "Custom/Combat/Release/SpreadReleaseData")]
    public class SpreadReleaseData : ScriptableObject
    {
        public int ShotsPerRelease;
        public RangeValue Angle;
        public float MinForceModifier;
    }
}
