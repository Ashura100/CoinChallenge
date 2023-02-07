using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
            //uiText.text = $"{remainingDuration /60} : {remainingDuration %60}";
            remainingDuration--;
            yield return new WaitForSeconds(1f);

        }
        OnEnd();
    }

    void OnEnd()
    {
        print ("Fin");
    }
}
