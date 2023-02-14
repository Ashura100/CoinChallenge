using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    int highScore = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE " + score.ToString();
        highScoreText.text = "HIGHSCORE " + highScore.ToString();
    }

    public void AddCoins(int coinValue)
    {
        score += coinValue;
        scoreText.text = "SCORE " + score.ToString();
        if(highScore < score)
        {
            highScore = score;
        }
            //PlayerPrefs.SetInt("highscore", score);
    }
}
