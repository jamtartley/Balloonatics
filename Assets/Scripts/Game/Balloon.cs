using Balloonatics.Combat;
using Balloonatics.Player;
using Balloonatics.Utils;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Balloonatics.Game
{
    [RequireComponent(typeof(Rigidbody2D), typeof(FixedJoint2D))]
    public class Balloon : MonoBehaviour
    {
        [SerializeField] public BalloonPart StringHandlePrefab;
        [SerializeField] public BalloonPart StringCentralPrefab;
        [SerializeField] public BalloonPart BalloonHeadPrefab;
        [HideInInspector] public PlayerController Controller;

        [SerializeField] private BalloonData data;
        private Rigidbody2D body;
        private FixedJoint2D fixedJoint;
        private BalloonPart head;
        private float force;

        private void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            fixedJoint = GetComponent<FixedJoint2D>();
            force = data.Force.Random();
        }

        private void Update()
        {
            head.Body.velocity = new Vector2(head.Body.velocity.x, force * (Controller ? 1f : 0.5f));
        }

        private void IgnoreCollisionWithOwner()
        {
            IEnumerable<Collider2D> playerColls = Controller.GetComponentsInChildren<Collider2D>();
            IEnumerable<Collider2D> balloonColls = Controller.Balloons.SelectMany(b => b.transform.GetComponentsInChildren<Collider2D>());
            List<Collider2D> allColls = playerColls.Concat(balloonColls).ToList();

            for (int i = 0; i < allColls.Count; i++)
            {
                for (int j = i + 1; j < allColls.Count; j++)
                {
                    Physics2D.IgnoreCollision(allColls[i], allColls[j]);
                }
            }
        }

        public void Init(Rigidbody2D hand, PlayerController controller, Color? overrideColour)
        {
            this.Controller = controller;

            Color colour = overrideColour ?? data.Colours.GetRandomElement();

            fixedJoint.connectedBody = hand;

            BalloonPart handle = Instantiate(StringHandlePrefab, transform.position, Quaternion.identity, transform);
            handle.Balloon = this;
            handle.Joint.connectedBody = body;
            handle.GetComponent<FixedJoint2D>().connectedBody = body;

            BalloonPart prevPart = handle;

            var sectionCount = data.Sections.Random();

            for (int i = 0; i < sectionCount; i++)
            {
                BalloonPart stringPart = Instantiate(StringCentralPrefab, prevPart.transform.position, Quaternion.identity, transform);
                stringPart.Balloon = this;
                stringPart.Joint.connectedBody = prevPart.Body;
                stringPart.Renderer.color = colour;

                prevPart = stringPart;
            }

            head = Instantiate(BalloonHeadPrefab, prevPart.transform.position, Quaternion.identity, transform);
            head.Balloon = this;
            head.IsHead = true;
            head.Joint.connectedBody = prevPart.Body;
            head.Renderer.color = colour;

            head.GetComponent<Health>().OnDie += (source) =>
            {
                Destroy(gameObject);
            };

            var sortingOrder = Random.Range(-4, -1000);
            foreach (var bp in GetComponentsInChildren<BalloonPart>()) bp.Renderer.sortingOrder = sortingOrder;
            head.Renderer.sortingOrder = sortingOrder + 1;

            IgnoreCollisionWithOwner();
        }
    }
}
