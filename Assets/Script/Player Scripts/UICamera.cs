using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    public Transform player;
    public float xPos;
    public float yPos;
    public float zPos;
    // Start is called before the first frame update
    void Start()
    {
        transform.position =  new Vector3(player.position.x + xPos, player.position.y + yPos, zPos);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + xPos, player.position.y + yPos, zPos);
    }
}
