using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    /*[SerializeField]
    private AudioClip KeyCollect = null;*/


    void Start()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            //AudioSource.PlayClipAtPoint(KeyCollect, transform.position);
            ScoreManager.instance.AddKeys();
            Destroy(gameObject);
        }
    }
}
