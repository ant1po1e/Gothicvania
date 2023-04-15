using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health, maxHealth;
    public Image healthBar;
    bool isInmune;
    public float InmunityTime;
    Blink material;
    SpriteRenderer sprite;
    Rigidbody2D rb;
    public float knockbackForceX;
    public float knockbackForceY;
    Animator anim;
    public static PlayerHealth instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
        health = maxHealth;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !isInmune)
        {
            health -= collision.GetComponent<Enemy>().damageToGive;
            StartCoroutine(Inmunity());

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
                print("player ded");
            }
        }
    }
    IEnumerator Inmunity()
    {
        isInmune = true;
        sprite.material = material.blink;
        anim.SetBool("Hurt", true);
        yield return new WaitForSeconds(InmunityTime / 5f);
        sprite.material = material.original;
        yield return new WaitForSeconds(InmunityTime / 5f);
        sprite.material = material.blink;
        yield return new WaitForSeconds(InmunityTime / 5f);
        sprite.material = material.original;
        yield return new WaitForSeconds(InmunityTime / 5f);
        sprite.material = material.blink;
        yield return new WaitForSeconds(InmunityTime / 5f);
        sprite.material = material.original;
        isInmune = false;
        anim.SetBool("Hurt", false);
    }

}
