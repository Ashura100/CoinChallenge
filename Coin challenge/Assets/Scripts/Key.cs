using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private AudioClip CoinCollect = null;


    void Start()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(CoinCollect, transform.position);
            ScoreManager.instance.AddKeys();
            Destroy(gameObject);
        }
    }
}
