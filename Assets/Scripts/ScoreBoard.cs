using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreText;

    //int highScore;
    public Text highScore;

    //[SerializeField] int scorePerHit = 10; //todo send to enemy class


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();

        

        highScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
    }

    public void ScoreHit(int scoreGain)
    {
        score = score + scoreGain;
        scoreText.text = score.ToString();

        if (score > PlayerPrefs.GetInt("HighScore", 0)) {

            PlayerPrefs.SetInt("HighScore", score);
            highScore.text = score.ToString();
        }

        

    }

    public void UpdateHighScore() {

      

    }
}
