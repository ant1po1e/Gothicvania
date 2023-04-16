using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject BossGO;

    private void Start()
    {
        BossGO.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossTrigger();
            StartCoroutine(WaitForBoss());
            AudioManager.instance.PlayAudio(AudioManager.instance.bossBGM);
        }
    }

    IEnumerator WaitForBoss()
    {
        var currentSpeed = PlayerController.instance.speed;
        PlayerController.instance.speed = 0;
        BossGO.SetActive(true); 
        yield return new WaitForSeconds(3f);
        PlayerController.instance.speed = currentSpeed;
        Destroy(gameObject);
    }
}
