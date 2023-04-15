using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubWeapons : MonoBehaviour
{
    public int SpearCost;

    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UseSubWeapon();
    }

    public void UseSubWeapon()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            if (Input.GetButtonDown("Fire2") && SpearCost <= Spears.instance.spearsAmount)
            {
                Spears.instance.SubItem(-SpearCost);
                GameObject subItem = Instantiate(arrow, transform.position, Quaternion.Euler(0, 0, -132));

                if (transform.localScale.x < 0)
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800f, 0f), ForceMode2D.Force);
                    subItem.transform.localScale = new Vector2(subItem.transform.localScale.x * -1, subItem.transform.localScale.y * -1);
                }
                else
                {
                    subItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(800f, 0f), ForceMode2D.Force);
                }
            }
        }
    }
}
