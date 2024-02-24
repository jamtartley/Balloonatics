using UnityEngine;

namespace Balloonatics.Combat
{
    public class DieInSeconds : MonoBehaviour
    {
        [SerializeField] private float seconds;

        private void Start()
        {
            Destroy(gameObject, seconds);
        }
    }
}
