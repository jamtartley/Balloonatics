using UnityEngine;

namespace Balloonatics.Combat
{
    [RequireComponent(typeof(Health))]
    public class DestroyOnDeath : MonoBehaviour
    {
        [SerializeField] private GameObject DeathEffectPrefab;

        private void Start()
        {
            GetComponent<Health>().OnDie += (source) =>
            {
                if (DeathEffectPrefab)
                {
                    Instantiate(DeathEffectPrefab, transform.position, Quaternion.identity, null);
                }

                Destroy(gameObject);
            };
        }
    }
}
