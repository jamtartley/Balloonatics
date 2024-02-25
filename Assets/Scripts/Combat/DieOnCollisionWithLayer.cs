using Balloonatics.Utils;
using UnityEngine;

public class DieOnCollisionWithLayer : MonoBehaviour
{
    [SerializeField] private LayerMask layersToDie;

    private void OnHit(Collider2D collider)
    {
        if (collider.gameObject.IsLayerInMask(layersToDie))
        {
            gameObject.DestroyMaybeAfterParticles();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnHit(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        OnHit(collider);
    }
}
