using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text uiText;

    public int Duration;
    private int remainingDuration;

    private void Start()
    {
        Being(Duration);
        Debug.Log(gameObject.name + "**************************");
    }
    //fonction qui met en marche le timer
    void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    //coroutine qui met � jour le d�compte du temps et appelle la fonction OnEnd
    IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            uiText.text = $"{remainingDuration /60} : {remainingDuration %60}";
            remainingDuration--;
            yield return new WaitForSeconds(1f);

        }
        OnEnd();
    }
    //charge la scene gameover une fois la fonction appel�e
    void OnEnd()
    {
        print ("Fin");
        SceneManager.LoadScene("GameOver");
    }
}
