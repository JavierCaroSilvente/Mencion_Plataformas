using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedPlayer = 8;
    public Animator anim;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    [SerializeField] bool isGrounded = false;

    private bool jump = false;
    private int currentJumps;
    private int totalJumps;
    public float jumpForce;
    float movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
       

        Movement();
        DirDetect();
        GroundCheck();
    }

    private void Movement()
    {
        rb.velocity = new Vector2(speedPlayer * Input.GetAxis("Horizontal"), rb.velocity.y); // <--------------------- con este no vibra al colisionar con las paredes y objetos.

        if (isGrounded)
        {
            float movement = rb.velocity.x;
            anim.SetFloat("MoveSpeed", Mathf.Abs(movement));
        }
    }

    void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0 )
        {
            isGrounded = true;
            anim.SetBool("IsGrounded", true);
        }
    }

    private void Jump()
    {
        anim.SetFloat("yVelocity", rb.velocity.y);
        

        if (Input.GetAxis("Jump") > 0 && isGrounded)
        {
            anim.SetFloat("MoveSpeed", 0);
            rb.velocity = new Vector2(rb.velocity.y, 0);
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
    }

    private void DirDetect()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
