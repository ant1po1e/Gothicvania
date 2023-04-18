using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

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
    public GameObject gameOverPanel;
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
        gameOverPanel.SetActive(false);
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
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);
                gameObject.SetActive(false);
                AudioManager.instance.backgroundMusic.Stop();
                AudioManager.instance.playerHit.Stop();
                AudioManager.instance.enemyDead.Stop();
                AudioManager.instance.gems.Stop();
                AudioManager.instance.heal.Stop();
                AudioManager.instance.arrow.Stop();
                AudioManager.instance.lvlUp.Stop();
                AudioManager.instance.flame.Stop();
                AudioManager.instance.buttonUI.Stop();
                AudioManager.instance.gameOver.Stop();
                AudioManager.instance.bossDead.Stop();
                AudioManager.instance.bossBGM.Stop();
                AudioManager.instance.PlayAudio(AudioManager.instance.gameOver);

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
