using Balloonatics.Player;
using Balloonatics.Utils;
using UnityEngine;

namespace Balloonatics.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private HealthData data;
        [HideInInspector] public System.Action<float, float, PlayerController> OnHealthChange;
        [HideInInspector] public System.Action<PlayerController> OnDie;
        [HideInInspector] public float CurrentHealth;
        [HideInInspector] public bool IsAlive => CurrentHealth > 0;

        private bool hasNotifiedDeath;

        private void Awake()
        {
            CurrentHealth = data.InitialHealth;
        }

        public void Die()
        {
            TakeDamage(CurrentHealth, null);
        }

        public void TakeDamage(float damage, Vector2? impactPosition, PlayerController source = null)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - damage, 0, data.InitialHealth);

            OnHealthChange?.Invoke(damage, CurrentHealth, source);

            if (data.ImpactPrefab != null)
            {
                Instantiate(data.ImpactPrefab, impactPosition ?? transform.position.ToVector2(), Quaternion.identity, null);
            }

            if (CurrentHealth <= 0 && !hasNotifiedDeath)
            {
                OnDie?.Invoke(source);
                hasNotifiedDeath = true;
            }
        }
    }
}
