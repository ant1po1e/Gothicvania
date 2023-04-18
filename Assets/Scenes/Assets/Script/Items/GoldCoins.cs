using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoins : MonoBehaviour
{
    public float cashToGive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.gems);
            BankAccount.instance.Money(cashToGive);
            Destroy(gameObject);
        }
    }
}
