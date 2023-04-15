using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject bossBarrier;

    public static BossUI instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        bossPanel.SetActive(false);
        bossBarrier.SetActive(false);   
    }

    public void BossTrigger()
    {
        bossPanel.SetActive(true);
        bossBarrier.SetActive(true);
    }

    public void BossDeactive()
    {
        bossPanel.SetActive(false);
        bossBarrier.SetActive(false);
    }
}
