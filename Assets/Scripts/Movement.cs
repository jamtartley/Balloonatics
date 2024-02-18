using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) body.AddForce(Vector2.left * speed);
        if (Input.GetKeyDown(KeyCode.D)) body.AddForce(Vector2.right * speed);
    }
}
