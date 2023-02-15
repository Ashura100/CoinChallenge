using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    DeadZone dz;
    private void Start()
    {
        dz = GameObject.Find("DeadZone").GetComponent<DeadZone>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            dz.respawnPositions = gameObject.transform.position;
            Debug.Log("tombé");
        }
    }
}
