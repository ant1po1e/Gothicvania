using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rb;
    Vector2 moveDirection;
    PlayerController target;

    void Start()
    {
        moveSpeed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        target = PlayerController.instance;

        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    void Update()
    {

    }
}
