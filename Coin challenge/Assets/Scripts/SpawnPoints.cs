using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [SerializeField]
    private GameObject coins;
    [SerializeField]
    private Transform[] spawnPoints;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject instantiated = Instantiate(coins);
            instantiated.transform.position = randomPoint.position;

        }
    }
}
