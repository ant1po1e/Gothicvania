using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeight;
    float velocityY, velocityX;
    Rigidbody2D rb;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipCharacter();
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);

        if (isGrounded)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }

        Attack();
        Jump();
        if (transform.position.x < -3.4f)
        {
            transform.position = new Vector2(-3.4f, transform.position.y);
        }
    }

    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        velocityX = Input.GetAxisRaw("Horizontal");
        velocityY = rb.velocity.y;

        rb.velocity = new Vector2(velocityX * speed, velocityY);
        if (rb.velocity.x != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    public void Attack()
    {
        if (Input.GetButton("Fire1"))
        {
            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    public void FlipCharacter()
    {
        if (velocityX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (velocityX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }
}
