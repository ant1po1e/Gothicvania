using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spears : MonoBehaviour
{
    public Text spearsText;
    public int spearsAmount;
    public int maxSpears;

    public static Spears instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        spearsText.text = "x " + spearsAmount.ToString() + " / " + maxSpears;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SubItem(int subItemAmount)
    {
        spearsAmount += subItemAmount;
        if (spearsAmount >= maxSpears)
        {
            spearsAmount = maxSpears;
        }
        spearsText.text = "x " + spearsAmount.ToString() + " / " + maxSpears;
    }
}
