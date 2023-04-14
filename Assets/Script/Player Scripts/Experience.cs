using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    public Image expImage;

    public Text currentLvlText;
    public int currentLvl;
    public float currentExp, expToNextLvl;

    public static Experience instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        currentLvl = 1;
        currentLvlText.text = currentLvl.ToString();
        expImage.fillAmount = currentExp / expToNextLvl;
    }

    void Update()
    {
        
    }

    public void AddExperience(float experience)
    {
        currentExp += experience;
        expImage.fillAmount = currentExp / expToNextLvl;

        if (currentExp >= expToNextLvl)
        {
            expToNextLvl = expToNextLvl * 2;
            currentExp = 0;
            PlayerHealth.instance.maxHealth += 10f;
            currentLvl++;
            currentLvlText.text = currentLvl.ToString();
        }
    }
}
