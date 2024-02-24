using System.Linq;
using UnityEngine;

namespace Balloonatics.Utils
{
    public class DestroyOnParticlesEnd : MonoBehaviour
    {
        private ParticleSystem[] particles;

        private void Awake()
        {
            particles = GetComponentsInChildren<ParticleSystem>().Concat(GetComponents<ParticleSystem>()).ToArray();
        }

        void Update()
        {
            if (particles.Any(p => p != null && p.IsAlive())) return;

            Destroy(gameObject);
        }
    }
}
