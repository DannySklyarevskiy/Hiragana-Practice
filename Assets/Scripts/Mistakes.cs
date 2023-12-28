using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Mistakes : MonoBehaviour
{
    public char currentLetter;
    public Translation currentTranslation;
    Generator generator;
    public List<char> letterMistakes;
    public List<Translation> translationMistakes;
    public GameObject[] mistakeButtons;

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        generator = FindObjectOfType<Generator>();

        //Do the following only on the game 
        if (scene.name == "Game")
        {
            //Find current letter and translation
            currentLetter = generator.randomLetter;
            currentTranslation = generator.currentTranslation;
        }

        //Do the following only on the mistakes scene 
        if (scene.name == "Mistakes")
        {
            //Find where to display mistakes
            mistakeButtons = GameObject.FindGameObjectsWithTag("Mistake display");

            //Find things to display/displays
            string translationMistake1 = translationMistakes[0].english.ToString();
            string letterMistake1 = "" + letterMistakes[0];
            GameObject mistakeButton1 = mistakeButtons[0];
            string translationMistake2 = translationMistakes[1].english.ToString();
            string letterMistake2 = "" + letterMistakes[1];
            GameObject mistakeButton2 = mistakeButtons[1];
            string translationMistake3 = translationMistakes[2].english.ToString();
            string letterMistake3 = "" + letterMistakes[2];
            GameObject mistakeButton3 = mistakeButtons[2];

            //Display mistakes
            mistakeButton1.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text =
            letterMistake1;
            mistakeButton1.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text =
            translationMistake1;

            mistakeButton2.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text =
            letterMistake2;
            mistakeButton2.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text =
            translationMistake2;

            mistakeButton3.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text =
            letterMistake3;
            mistakeButton3.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text =
            translationMistake3;
        }
    }

    public void AddMistakeToList()
    {
        letterMistakes.Add(currentLetter);
        translationMistakes.Add(currentTranslation);
    }
}
