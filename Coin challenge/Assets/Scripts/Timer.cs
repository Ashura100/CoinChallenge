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
    }

    void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }
    //coroutine qui met à jour le décompte du temps et appelle la fonction OnEnd
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
    //charge la scene gameover une fois la fonction appelée
    void OnEnd()
    {
        print ("Fin");
        SceneManager.LoadScene("GameOver");
    }
}
