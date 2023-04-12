using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator anim;

    public bool isStatic;
    public bool isWalk;
    public bool isPatrol;
    public bool Wait;
    public bool walksRight;

    public Transform wallCheck, pitCheck, groundCheck;
    bool wallDetected, pitDetected, isGrounded;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    public bool goToA, goToB;

    void Start()
    {
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);
        if ((pitDetected || wallDetected) && isGrounded)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        if (isWalk)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);
            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if (isPatrol)
        {
            anim.SetBool("Idle", false);
            if (goToA)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);

                if (Vector2.Distance(transform.position, pointA.position) < 0.2f)
                {
                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }

            if (goToB)
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);

                if (Vector2.Distance(transform.position, pointB.position) < 0.2)
                {
                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }

    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }
}




