using UnityEngine;

namespace Balloonatics.Combat
{
    [CreateAssetMenu(menuName = "Custom/Combat/HealthData")]
    public class HealthData : ScriptableObject
    {
        public float InitialHealth;
        public GameObject ImpactPrefab;
        public GameObject DeathPrefab;
    }
}
