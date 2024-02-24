using UnityEngine;

namespace Balloonatics.Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float releaseForce;

        private void Awake()
        {
            Debug.Assert(projectilePrefab != null);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 direction = (mousePos - spawnPoint.position).normalized;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                Quaternion aimQuat = Quaternion.AngleAxis(angle, Vector3.forward);

                var proj = Instantiate(projectilePrefab, spawnPoint.position, aimQuat, null);
                var body = proj.GetComponent<Rigidbody2D>();

                body.AddForce(direction * releaseForce, ForceMode2D.Impulse);
            }
        }
    }
}
