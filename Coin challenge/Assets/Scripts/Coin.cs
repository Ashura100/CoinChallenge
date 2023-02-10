using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    public int coinValue;
    [SerializeField]
    private AudioClip CoinCollect = null;
    private AudioSource coins_AudioSource;

    void Start()
    {
        coins_AudioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.AddCoins();
            Destroy(gameObject);
        }
        coins_AudioSource.PlayOneShot(CoinCollect);
    }
}
