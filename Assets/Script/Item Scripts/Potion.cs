using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public float healthToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().health += healthToGive;
            Destroy(gameObject);
            AudioManager.instance.PlayAudio(AudioManager.instance.heal);
        }
    }
}
