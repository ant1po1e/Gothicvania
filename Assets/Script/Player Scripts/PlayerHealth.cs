using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    public Image healthImg;
    public float immunityTime;
    public float knockbackForceX;
    public float knockbackForceY;
    bool isImmune;
    Rigidbody2D rb;
    Blink material;
    SpriteRenderer sprite;

    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        material = GetComponent<Blink>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        health = maxHealth;
    }

    private void Update()
    {
        healthImg.fillAmount = health / 100;

       if (health > maxHealth)
        {
            health = maxHealth;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isImmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Immunity());

            if (collision.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(-knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }

            if (health <= 0)
            {
                print("Player Dead");
            }    
        }
    }

    IEnumerator Immunity()
    {
        isImmune = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        sprite.material = material.original;
        isImmune = false;

    }
}
