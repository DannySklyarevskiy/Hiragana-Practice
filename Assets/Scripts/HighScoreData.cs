﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public int highScore;
    public HighScoreData (Score score)
    {
        highScore = score.highScore;
    }
}
