﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }
}
