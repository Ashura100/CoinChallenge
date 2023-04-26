using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public static Vector3 respawnPositions;
    //zone dans laquelle le joueur est considérer comme mort
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) 
        {
            collision.transform.position = respawnPositions;
            Debug.Log("tombé");
        }
    }
}
