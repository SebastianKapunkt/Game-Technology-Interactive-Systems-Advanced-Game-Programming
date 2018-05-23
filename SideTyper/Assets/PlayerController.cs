using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private Vector2 velocity;
    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        velocity = rigid.velocity;
        if (Input.GetKey("d") && velocity.x < 5)
        {
            rigid.AddForce(Vector2.right * speed);
        }
        if (Input.GetKey("a") && velocity.x > -5)
        {
            rigid.AddForce(Vector2.left * speed);
        }
        if (Input.GetKeyDown("space"))
        {
            rigid.AddForce(Vector2.up * jumpHeight);
        }
    }
}
