using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    GameManager gameManager;
    public Animator animator;
    public float Speed = 50f;

    [Space]

    [SerializeField]
    public float timeRemaining;
    public float MaxTime = 2;
    public float jumpForce = 10f;
    public float coyoteTime = 0.2f;

    [Space]

    private float coyoteTimeCounter;
    private float moveInput;
    private bool facingRight = true;

    public bool isGrounded = false;
    public float Length;
    public LayerMask groundLayer;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameManager = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    void Update() {
        Movement();
        Jumping();
    }

    void Movement() {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        if(moveInput > 0 && !facingRight)
        {
            Flip();
        }else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
        
    }


    void Jumping() {
    
        isGrounded = Physics2D.Raycast(transform.position, -Vector2.up, Length, groundLayer);
        Debug.DrawRay(transform.position, -Vector2.up * Length, Color.red);
        animator.SetBool("Grounded", isGrounded);

        if(isGrounded == true){
            coyoteTimeCounter = coyoteTime;
            timeRemaining -= Time.deltaTime;
        } else
        {
            timeRemaining = MaxTime;
            coyoteTimeCounter -= Time.deltaTime;
        }

        if(coyoteTimeCounter > 0 && timeRemaining < 0){
            gameManager.lastJumpPos = transform.position;
            FindObjectOfType<AudioManager>().Play("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if(timeRemaining < 0 && rb.velocity.y > 0){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }

    void Flip(){

        facingRight = !facingRight;
        transform.Rotate (0f, 180f, 0f);
    }


}
