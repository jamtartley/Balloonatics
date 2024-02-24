using Balloonatics.Combat;
using Balloonatics.Game;
using System.Collections.Generic;
using UnityEngine;

namespace Balloonatics.Player
{
    public class PlayerController : MonoBehaviour
    {
        [HideInInspector] public PlayerAim Aim;
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
            Input = GetComponent<PlayerInput>();
            Movement = GetComponent<PlayerMovement>();

            for (int i = 0; i < data.InitialBalloons; i++)
            {
                AddBalloon();
            }
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
