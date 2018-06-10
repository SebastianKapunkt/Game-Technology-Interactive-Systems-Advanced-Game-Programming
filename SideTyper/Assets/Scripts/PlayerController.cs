using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float currentMaxSpeed;
    [SerializeField]
    private float currentSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private Vector2 velocity;
    [SerializeField]
    private PlayerState state = PlayerState.RUN;
    [SerializeField]
    private FacingDirectionState facingDirection = FacingDirectionState.RIGHT;
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private float groundRadius = 0.2f;
    [SerializeField]
    private Transform groundCheck;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentMaxSpeed = maxSpeed;
        currentSpeed = speed;
    }

    void FixedUpdate()
    {
        if (Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround))
        {
            state = PlayerState.RUN;
        }
        if (Input.GetKey("d"))
        {
            move(FacingDirectionState.RIGHT);
        }
        if (Input.GetKey("a"))
        {
            move(FacingDirectionState.LEFT);
        }
        if (Input.GetKeyDown("space"))
        {
            jump();
        }
    }

    private void jump()
    {
        if (!state.Equals(PlayerState.JUMP))
        {
            state = PlayerState.JUMP;
            rigid.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }
    }

    private void move(FacingDirectionState wantedState)
    {
        facingDirection = wantedState;
        velocity = rigid.velocity;
        if (facingDirection.Equals(FacingDirectionState.RIGHT) && velocity.x < currentMaxSpeed)
        {
            rigid.AddForce(Vector2.right * currentSpeed);
        }
        if (facingDirection.Equals(FacingDirectionState.LEFT) && velocity.x > -currentMaxSpeed)
        {
            rigid.AddForce(Vector2.left * currentSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("collectable"))
        {
            other.gameObject.SetActive(false);
            currentSpeed += 250;
            currentMaxSpeed += 3;
            Invoke("SetSpeedNormal", 5);
        }
    }

    private void SetSpeedNormal(){
        currentSpeed = speed;
        currentMaxSpeed = maxSpeed;
    }

}
