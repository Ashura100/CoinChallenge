using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Transform currentCheckPoint;

    void OnTriggerEnter(Collider collision)
    {
        collision.transform.position = currentCheckPoint.position;
    }
}
