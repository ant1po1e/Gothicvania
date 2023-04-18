using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public GameObject BossGO;
    public GameObject Barrier;

    private void Start()
    {
        BossGO.SetActive(false);
        Barrier.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instance.BossTrigger();
            StartCoroutine(WaitForBoss());
            AudioManager.instance.PlayAudio(AudioManager.instance.bossBGM);
            AudioManager.instance.StopAudio(AudioManager.instance.backgroundMusic);
        }
    }

    IEnumerator WaitForBoss()
    {
        var currentSpeed = PlayerController.instance.speed;
        PlayerController.instance.speed = 0;
        BossGO.SetActive(true);
        Barrier.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerController.instance.speed = currentSpeed;
        gameObject.SetActive(false);
    }
}
