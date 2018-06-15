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
    [SerializeField]
    private List<GameObject> collectables;
    [SerializeField]
    private CanvasController canvasController;
    private Vector3 startPosition;
    private Animator animator;


    private float speedBoost = 250;
    private float maxSpeedBoost = 3;

    private Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentMaxSpeed = maxSpeed;
        currentSpeed = speed;
        canvasController.init();
        animator = GetComponent<Animator>();
        startPosition = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            gameObject.transform.position.z
        );
    }

    void Update(){
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        animator.SetFloat("vSpeed", rigid.velocity.y);

        if(state.Equals(PlayerState.JUMP)){
            animator.SetBool("Ground", false);
        } else {
            animator.SetBool("Ground", true);
        }
    }

    void FixedUpdate()
    {
        velocity = rigid.velocity;
        if (!state.Equals(PlayerState.DEAD) && !state.Equals(PlayerState.WON))
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
        else
        {
            if (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))
            {
                restartGame();
            }
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
            currentSpeed += speedBoost;
            currentMaxSpeed += maxSpeedBoost;
            Invoke("SetSpeedNormal", 5);
        }

        if (other.gameObject.CompareTag("ground_is_lava"))
        {
            state = PlayerState.DEAD;
            canvasController.lose();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            state = PlayerState.WON;
            rigid.velocity = Vector3.zero;
            canvasController.win();
        }
    }

    private void SetSpeedNormal()
    {
        currentSpeed = currentSpeed - speedBoost;
        currentMaxSpeed = currentMaxSpeed - maxSpeedBoost;
    }

    private void restartGame()
    {
        canvasController.init();
        rigid.velocity = Vector3.zero;
        gameObject.transform.position = startPosition;
        state = PlayerState.RUN;
        foreach (GameObject item in collectables)
        {
            item.SetActive(true);
        }
    }

}
