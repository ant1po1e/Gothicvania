using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public float bank;
    public Text gemsCount;
    public static Currency instance;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        gemsCount.text = "x " + bank.ToString();
    }

    public void Money(float cashCollected)
    {
        bank += cashCollected;
        gemsCount.text = "x " + bank.ToString();
    }
}
