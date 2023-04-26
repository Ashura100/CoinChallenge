using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;
    public Text keyNumberText;

    int score = 0;
    int highScore = 0;
    int key = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    //affiche le score, highscore et clées en début de jeu
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE " + score.ToString();
        highScoreText.text = "HIGHSCORE " + highScore.ToString();
        keyNumberText.text = "Key Number " + key.ToString();

    }
    //met à jour les points des pièces en fonction de leur valeur
    public void AddCoins(int coinValue)
    {
        score += coinValue;
        scoreText.text = "SCORE " + score.ToString();
        if (highScore < score)
        {
            highScore = score;
        }
        //PlayerPrefs.SetInt("highscore", score);
    }
    //met à jour le nombre de clée
    public void AddKeys()
    {
        key += 1;
        keyNumberText.text = "Key Number " + key.ToString();
    }
}
