using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    public int coinValue;
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
            ScoreManager.instance.AddCoins(coinValue);
            Destroy(gameObject);
        }
    }
}
