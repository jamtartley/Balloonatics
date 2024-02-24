using UnityEngine;

namespace Balloonatics.Utils
{
    public static class GameObjectExtensions
    {
        public static void DestroyMaybeAfterParticles(this GameObject go)
        {
            if (!go) return;

            var particles = go.GetComponentsInChildren<ParticleSystem>();

            if (particles.Length == 0 || !go.GetComponent<DestroyOnParticlesEnd>())
            {
                GameObject.Destroy(go);
            }
            else
            {
                foreach (var p in particles)
                {
                    p.Stop();
                }
            }
        }

        public static T GetFirstUpHierarchy<T>(this GameObject go) where T : Component
        {
            GameObject current = go;

            while (current != null)
            {
                T ret = current.GetComponent<T>();

                if (ret != null) return ret;
                else
                {
                    if (!current.transform.parent) return null;
                    else current = current.transform.parent.gameObject;
                }
            }

            return null;
        }

        public static bool IsLayerInMask(this GameObject gameObject, LayerMask layerMask)
        {
            return layerMask == (layerMask | (1 << gameObject.layer));
        }
    }
}
