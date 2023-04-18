using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;
    public bool isDamaged;
    public GameObject deathEffect;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaged)
        {
            // enemy.healthPoints -= 1f;
            enemy.healthPoints -= collision.GetComponent<WeaponStats>().DamageInput(enemy.defense, this.transform);

            if (collision.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);

            }
            else
            {
                rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);

            }


            StartCoroutine(Damager());

            if (enemy.healthPoints <= 0)
            {
                AudioManager.instance.PlayAudio(AudioManager.instance.enemyDead);
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                ExpScript.instance.expModifier(enemy.expToGive);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f / 3);
        sprite.material = material.original;
        yield return new WaitForSeconds(0.5f / 3);
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f / 3);
        sprite.material = material.original;
        isDamaged = false;
    }
}
