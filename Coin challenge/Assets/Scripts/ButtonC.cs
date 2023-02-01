using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonC : MonoBehaviour
{
    public string levelToLoad;

    public GameObject Parametre;
    public void JouerButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void OptionButton()
    {
        Parametre.SetActive(true);
    }

    public void QuitterReglageMenu()
    {
        Parametre.SetActive(false);
    }
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
