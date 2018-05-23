using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private Vector2 velocity;
    private Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        velocity = rigidbody2D.velocity;
        if (Input.GetKey("d") && velocity.x < 5)
        {
            rigidbody2D.AddForce(Vector2.right * speed);
        }
        if (Input.GetKey("a") && velocity.x > -5)
        {
            rigidbody2D.AddForce(Vector2.left * speed);
        }
    }
}
