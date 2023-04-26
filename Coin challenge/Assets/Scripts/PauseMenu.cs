using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenu;
    //canvas du menu pause désactivé quand le jeu se lance
    void Start()
    {
        pauseMenu.SetActive(false);
    }
    //si on appuie sur echap le jeu met en marche les fonctions pause et continuer
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPause)
            {
                Continuer();
            }
            else
            {
                Pause();
            }
        }
    }
    //fonction pause active le canvas du menu pause, bloque les mouvements du joueur, met unity en pause
    void Pause()
    {
        PersonnageController.instance.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
    //fonction continuer désactive le canvas, active les mouvements du joueur et relance unity
    public void Continuer()
    {
        PersonnageController.instance.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
    //renvoit vers la scene start
    public void StartScene()
    {
        Continuer();
        SceneManager.LoadScene("Start");
    }
}
