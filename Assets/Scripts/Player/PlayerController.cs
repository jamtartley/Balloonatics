using Balloonatics.Combat;
using Balloonatics.Game;
using Balloonatics.Utils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Balloonatics.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public PlayerAim Aim;
        [HideInInspector] public Health Health;
        [HideInInspector] public PlayerInput Input;
        [HideInInspector] public PlayerMovement Movement;
        [HideInInspector] public Weapon Weapon;
        [HideInInspector] public List<Balloon> Balloons = new List<Game.Balloon>();
        public Balloon BalloonPrefab;

        [Space]
        public Transform RightHand;
        public Rigidbody2D LeftHand;
        public Transform Head;

        [SerializeField] private PlayerControllerData data;

        private void Start()
        {
            Aim = GetComponent<PlayerAim>();
            Health = GetComponent<Health>();
            Input = GetComponent<PlayerInput>();
            Movement = GetComponent<PlayerMovement>();

            GetComponent<Health>().OnDie += (killer) =>
            {
                Destroy(Aim);
                Destroy(Input);
                Destroy(Movement);

                foreach (var joint in GetComponentsInChildren<Joint2D>().GetRandomSelection(0.3f))
                {
                    Destroy(joint);
                }

                foreach (var rb in GetComponentsInChildren<Rigidbody2D>())
                {
                    rb.interpolation = RigidbodyInterpolation2D.None;
                    rb.drag = 0; // Prevent aiming arm dropping slowly due to having high drag
                    rb.gravityScale = 8;
                }
            };

            for (int i = 0; i < data.InitialBalloons; i++)
            {
                AddBalloon();
            }
        }

        private void Update()
        {
            Balloons = Balloons.Where(b => b).ToList();
            if (Balloons.Count == 0) Health.Die();
        }

        private void AddBalloon(Color? overrideColour = null)
        {
            var balloon = Instantiate(BalloonPrefab, LeftHand.transform.position, Quaternion.identity, null);
            balloon.transform.Rotate(Vector3.forward * Random.Range(-50, 50));
            Balloons.Add(balloon);

            balloon.Init(LeftHand, this, overrideColour);
        }
    }
}
