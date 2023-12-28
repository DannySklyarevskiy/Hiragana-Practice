using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Score : MonoBehaviour
{
    public int currentScore;
    public int highScore = 0;
    [SerializeField] int scoreAddAmount;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI highScoreDisplay;

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        //Do the following only on the game over scene
        if (scene.name == "Game over")
        {
            //Find displays 
            scoreDisplay = GameObject.Find("Score display").GetComponent<TextMeshProUGUI>();
            highScoreDisplay = GameObject.Find("High score display").GetComponent<TextMeshProUGUI>();

            //Set high score
            if (currentScore > highScore)
            {
                highScore = currentScore;
            }

            //Display score
            scoreDisplay.text = "Score: " + currentScore.ToString();
            highScoreDisplay.text = "High score: " + highScore.ToString();
        }
    }

    public void addToScore()
    {
        currentScore += scoreAddAmount;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
