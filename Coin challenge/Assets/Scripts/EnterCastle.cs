using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCastle : MonoBehaviour
{
    public string nomScene;
    //une fois le joueur dans la zone de collision charge la scene choisis (scenedonjon)
    void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(nomScene);
        }
    }
}
