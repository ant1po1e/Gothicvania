using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float secondsToDestroy;

    private void start()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}
