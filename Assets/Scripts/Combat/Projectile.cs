using System.Collections.Generic;
using UnityEngine;

namespace Balloonatics.Combat
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour
    {
        [HideInInspector] public Weapon Weapon;
        [HideInInspector] public Rigidbody2D Body;

        private IEnumerable<Effect> effects;

        private void Awake()
        {
            effects = GetComponents<Effect>();
            Body = GetComponent<Rigidbody2D>();
        }

        private void OnHit(Collider2D collider)
        {
            foreach (var effect in effects)
            {
                effect.Use(collider.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            OnHit(collider);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnHit(collision.collider);
        }
    }
}
