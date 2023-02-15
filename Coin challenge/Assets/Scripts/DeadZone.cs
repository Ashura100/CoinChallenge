using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public Vector3 respawnPositions;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.transform.position = respawnPositions;
            Debug.Log("tombé");
        }
    }
}
