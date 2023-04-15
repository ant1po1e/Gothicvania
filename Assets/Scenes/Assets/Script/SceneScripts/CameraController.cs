using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Transform activeRoom;

    public static CameraController instance;

    [Range(-5, 5)]
    public float minModX, maxModX, minModY, maxModY;

    public float dampSpeed;
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

    }

    // Update is called once per frame
    void Update()
    {
        var minPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.min.y + minModY;
        var maxPosY = activeRoom.GetComponent<BoxCollider2D>().bounds.max.y + maxModY;
        var minPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.min.x + minModX;
        var maxPosX = activeRoom.GetComponent<BoxCollider2D>().bounds.max.x + maxModX;

        Vector3 clampPos = new Vector3(
            Mathf.Clamp(player.position.x, minPosX, maxPosX),
            Mathf.Clamp(player.position.y, minPosY, maxPosY),
            Mathf.Clamp(player.position.z, -10f, -10f)
            );

        Vector3 smoothPos = Vector3.Lerp(transform.position, clampPos, dampSpeed * Time.deltaTime);
        transform.position = smoothPos;
    }
}
