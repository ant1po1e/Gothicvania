using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviour : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;

    public float timeToShoot, countDown;
    public float timeToTP, countDownToTP;


    public float bossHealth, currentHealth;
    public Image HealthImg;

    private void Start()
    {
        var initialPosition = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPosition].position;
        countDown = timeToShoot;
        countDownToTP = timeToTP;
    }

    private void Update()
    {
        CountDown();
        DamageBoss();
        BossScale();
    }

    public void CountDown()
    {
        countDown -= Time.deltaTime;
        countDownToTP -= Time.deltaTime;

        if (countDown <= 0f)
        {
            ShootPlayer();
            countDown = timeToShoot;
            Teleport();
        }

        if (countDownToTP <= 0)
        {
            countDownToTP = timeToTP;
            Teleport();
        }
    }

    public void ShootPlayer()
    {
            GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
    }

    public void Teleport()
    {
        transform.position = transforms[1].position;
        countDown = timeToShoot;
        countDownToTP = timeToTP;
    }

    public void DamageBoss()
    {
        currentHealth = GetComponent<Enemy>().healthPoints;
        HealthImg.fillAmount = currentHealth / bossHealth;
    }

    private void OnDestroy()
    {
        BossUI.instance.BossDeactive();
    }
    
    public void BossScale()
    {
        if (transform.position.x > PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-2, 2, 2);
        }

        else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }
} 