using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //charge la scene choisis 
    public void chargerScene(string nomScene)
    {
        SceneManager.LoadScene(nomScene);
    }
    //quitte le jeu
    public void Exit()
    {
        if (Application.isEditor)//jeu tourne dans l'editeur
        {
#if UNITY_EDITOR //Build = Directive de compilation(transformation langage de haut niveau en langage machine)  = si editor =/ compilation ignoré
            UnityEditor.EditorApplication.isPlaying = false;
#endif


        }
        else
        {
            Application.Quit();
        }
    }
}
