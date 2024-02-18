using UnityEngine;

namespace Balloonatics.Game
{
    [RequireComponent(typeof(Rigidbody2D), typeof(HingeJoint2D), typeof(SpriteRenderer))]
    public class BalloonPart : MonoBehaviour
    {
        [HideInInspector] public Rigidbody2D Body;
        [HideInInspector] public HingeJoint2D Joint;
        [HideInInspector] public SpriteRenderer Renderer;
        [HideInInspector] public Balloon Balloon;

        private void Awake()
        {
            Body = GetComponent<Rigidbody2D>();
            Joint = GetComponent<HingeJoint2D>();
            Renderer = GetComponent<SpriteRenderer>();
        }
    }
}
