using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Transform currentCheckPoint;
    //sauvegarde la position du joueur une fois rentr� dans le boxcollider
    void OnTriggerEnter(Collider collision)
    {
        collision.transform.position = currentCheckPoint.position;
    }
}
