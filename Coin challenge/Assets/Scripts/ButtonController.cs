using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public string levelToLoad;

    public GameObject Parametre;
    //fonction du bouton jouer lance la scene EnterScene en chargeant la scene
    public void JouerButton()
    {
        SceneManager.LoadScene(levelToLoad);
    }
    //fonction du bouton option active le canvas param�tre
    public void OptionButton()
    {
        Parametre.SetActive(true);
    }
    //fonction du bouton quitter option d�sactive le canvas param�tre
    public void QuitterReglageMenu()
    {
        Parametre.SetActive(false);
    }
    //fonction quitter, quitte le jeu
    public void Exit()
    {
        if (Application.isEditor)//jeu tourne dans l'editeur
        {
#if UNITY_EDITOR //Build = Directive de compilation(transformation langage de haut niveau en langage machine)  = si editor =/ compilation ignor�
            UnityEditor.EditorApplication.isPlaying = false;
#endif


        }
        else
        {
            Application.Quit();
        }
    }
}
