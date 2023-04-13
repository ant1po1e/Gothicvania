using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exp : MonoBehaviour
{
    public Image expImage;
    public float currentExp, expToNextLvl;

        public static Exp instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        expImage.fillAmount = currentExp / expToNextLvl;
    }

    void Update()
    {
        
    }

    public void expMod(float experience)
    {
        currentExp += experience;

        if (currentExp >= expToNextLvl)
        {
            expToNextLvl = expToNextLvl * 2;
            currentExp = 0;
            print("Leveled up!");
        }
    }
}
