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
    //affiche le score, highscore et cl�es en d�but de jeu
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE " + score.ToString();
        highScoreText.text = "HIGHSCORE " + highScore.ToString();
        keyNumberText.text = "Key Number " + key.ToString();

    }
    //met � jour les points des pi�ces en fonction de leur valeur
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
    //met � jour le nombre de cl�e
    public void AddKeys()
    {
        key += 1;
        keyNumberText.text = "Key Number " + key.ToString();
    }
}
