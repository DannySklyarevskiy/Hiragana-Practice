using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    SceneTransitions sceneTransitions;
    public int health = 3;
    [SerializeField] Image heartOne;
    [SerializeField] Image heartTwo;
    [SerializeField] Image heartThree;

    //If health is 0, load game over
    private void CheckIfHealthIsZero()
    {
        if (health == 0)
        {
            FindObjectOfType<SceneTransitions>().LoadGameOverSceneFunction();
        }
    }

    //Decrease amount of health
    public void subtractHealth()
    {
        health--;
        ChangeHeartDisplay();
        CheckIfHealthIsZero();
    }

    //Show amount  of health to player
    private void ChangeHeartDisplay()
    {
        if (health == 3)
        {
            heartThree.color = Color.red;
            heartTwo.color = Color.red;
            heartOne.color = Color.red;
        }
        if (health == 2)
        {
            heartThree.color = Color.black;
            heartTwo.color = Color.red;
            heartOne.color = Color.red;
        }
        if (health == 1)
        {
            heartThree.color = Color.black;
            heartTwo.color = Color.black;
            heartOne.color = Color.red;
        }
        if (health == 0)
        {
            heartThree.color = Color.black;
            heartTwo.color = Color.black;
            heartOne.color = Color.black;
        }
    }
}
