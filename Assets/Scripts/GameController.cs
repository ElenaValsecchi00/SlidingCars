using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //variables
    public int score;
    private int highScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private EnemySpawner enemyS;

    // Start is called before the first frame update
    void Start()
    {
       enemyS = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
       highScore = PlayerPrefs.GetInt("HighScore");
       highScoreText.text = highScore.ToString();
    }

    //End Game
    public void End()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    //Increase the Score
    public void IncreaseScore(int additionalScore)
    {
        score += additionalScore;
        scoreText.SetText(score.ToString());
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        enemyS.AccelerateSpawn();
    }

    //Pause game
    public void Pause()
    {
        Time.timeScale = 0; 
    }
    
    //Resume game
    public void Resume()
    {
        Time.timeScale = 1;
    }
}
