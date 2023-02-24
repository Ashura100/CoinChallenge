using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }
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

    void Pause()
    {
        PersonnageController.instance.enabled = false;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true;
    }
    public void Continuer()
    {
        PersonnageController.instance.enabled = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
    public void StartScene()
    {
        Continuer();
        SceneManager.LoadScene("Start");
    }
}
