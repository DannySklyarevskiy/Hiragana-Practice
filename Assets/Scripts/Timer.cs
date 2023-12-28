using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float currentTime;
    public float staringTime;
    [SerializeField] TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = staringTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerText.text = "Time Left: " + Math.Round(currentTime, 1).ToString();
    }

    public void ResetTime()
    {
        currentTime = staringTime;
    }

    public void DecreaseStartTime()
    {
        staringTime = staringTime * 0.5f;
        if (staringTime <= 2f)
        {
            staringTime = 2f;
        }
    }
}
