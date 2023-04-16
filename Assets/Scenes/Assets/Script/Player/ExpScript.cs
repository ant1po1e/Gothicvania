using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpScript : MonoBehaviour
{
    public Image expBar;

    public float currentExp, currentLvl = 1, expNextLevel;
    public Text currentLvlText;
    public static ExpScript instance;
    // Start is called before the first frame update

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
        currentLvlText.text = "lv. " + currentLvl.ToString();
        expBar.fillAmount = currentExp / expNextLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void expModifier(float exp)
    {
        currentExp += exp;
        expBar.fillAmount = currentExp / expNextLevel;

        if (currentExp >= expNextLevel)
        {
            expNextLevel *= 1.6f;
            currentExp = 0;
            currentLvl += 1;
            PlayerHealth.instance.maxHealth *= 1.2f;
            Spears.instance.maxSpears += 5;
            PlayerStats.instance.attack += (1 * currentLvl / 10);
            currentLvlText.text = "lv. " + currentLvl.ToString();
        }
    }
}
