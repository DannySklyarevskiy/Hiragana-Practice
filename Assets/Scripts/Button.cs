using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public void CahngeScene()
    {
        if (tag == "Start")
        {
            FindObjectOfType<SceneTransitions>().LoadStartSceneFunction();
        }

        if (tag == "Game")
        {
            FindObjectOfType<SceneTransitions>().LoadGameSceneFunction();
        }

        if (tag == "Game over")
        {
            FindObjectOfType<SceneTransitions>().LoadGameOverSceneFunction();
        }

        if (tag == "Mistakes")
        {
            FindObjectOfType<SceneTransitions>().LoadMistakesSceneFunction();
        }

        SaveSystem.LoadHighScore();
    }

    public void QuitGame()
    {
        SaveSystem.SaveHighScore(FindObjectOfType<Score>());
        Application.Quit();
    }
}
