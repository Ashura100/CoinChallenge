using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //zone dans laquelle respawn le joueur
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            DeadZone.respawnPositions = gameObject.transform.position;
        }
    }
}
