using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Generator : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreDisplay;
    [SerializeField] TextMeshProUGUI japBox;
    [SerializeField] Translation[] translations;
    public bool hiraganaOn;
    public Translation currentTranslation;
    char[] hiragana = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもやゆよらりるれろわをん".ToCharArray();
    char[] katakana = "アイウエオカキクケコサシスセソタチツテトナニヌネノハヒフヘホマミムメモヤユヨラリルレロワヲン".ToCharArray();
    public char randomLetter;
    Translation translation;
    TextField textField;
    int letterIndex;
    Score score;
    Health health;
    ScreenShake screenShake;
    Timer timer;


    void Start()
    {
        //Find scripts
        translation = FindObjectOfType<Translation>();
        textField = FindObjectOfType<TextField>();
        score = FindObjectOfType<Score>();
        health = FindObjectOfType<Health>();
        screenShake = FindObjectOfType<ScreenShake>();
        timer = FindObjectOfType<Timer>();

        //Load first letter
        LoadNextLetter();
    }

    private void Update()
    {
        //If the answer is correct, increase score and load next letter
        if (Input.GetKeyDown(KeyCode.Return) && currentTranslation.english == textField.letter) 
        {
            LoadNextLetter();
            score.addToScore();
            screenShake.SmallCamShake();

            //If at least one letter is correct, the starting time becomes 10
            if (score.currentScore > 0)
            {
                timer.staringTime = 10;
            }

            //Every 100 points decrease start time
            if (score.currentScore % 100 == 0)
            {
                timer.DecreaseStartTime();
            }
        }

        //If the answer is wrong, decrease health and load next letter
        else if (Input.GetKeyDown(KeyCode.Return) && currentTranslation.english != textField.letter 
                 || timer.currentTime <= 0)
        {
            health.subtractHealth();
            FindObjectOfType<Mistakes>().AddMistakeToList();
            screenShake.CamShake();
            LoadNextLetter();
        }

        //Show score to player
        scoreDisplay.text = "Score: " + score.currentScore;
    }

    private void LoadNextLetter()
    {
        timer.ResetTime();
        randomLetter = hiragana[UnityEngine.Random.Range(0, 3)];
        japBox.text = randomLetter.ToString();
        if (hiraganaOn) { letterIndex = System.Array.IndexOf(hiragana, randomLetter); }
        else            { letterIndex = System.Array.IndexOf(katakana, randomLetter); }
        currentTranslation = translations[UnityEngine.Random.Range(letterIndex, letterIndex)];
    }
}
