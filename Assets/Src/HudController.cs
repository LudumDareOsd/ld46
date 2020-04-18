﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public ScoreText ScoreText;
    public UpgradeScreen UpgradeScreen;
    public WaveTexts WaveTexts;
    // Start is called before the first frame update
    void Start()
    {
        if (UpgradeScreen != null)
        {
            UpgradeScreen.Upgrade1_Clicked += Upgrade1Chosen;
            UpgradeScreen.Upgrade2_Clicked += Upgrade2Chosen;
            UpgradeScreen.Upgrade3_Clicked += Upgrade3Chosen;
            UpgradeScreen.CloseUpgradeScreenClicked += CloseUpgradeScreenChosen;
        }   
    }

    // Update is called once per frame
    void Update()
    {
	}

    public void SetScore(int score)
    {
        if (ScoreText != null)
        {
            ScoreText.UpdateScoreText(score);
        }
    }

    public void SetWave(int wave)
    {
        if (WaveTexts != null)
        {
            WaveTexts.WaveChange(wave);
        }
    }

    public void showUpgradeScreen(int favor, int playerweaponlevel, int walldefenselevel)
    {
        UpgradeScreen.ShowUpgradeScreen(favor, playerweaponlevel, walldefenselevel);
    }
    public void UpdateFavorLeft(int favor)
    {
        UpgradeScreen.updateFavorLeft(favor);
    }
    public void CloseUpgradeScreen()
    {
        UpgradeScreen.CloseUpgradeScreen();
    }
    public event EventHandler Upgrade1_Chosen;
    public void Upgrade1Chosen(object sender, EventArgs e)
    {
        var Upgrade1_Chosen_Event = Upgrade1_Chosen;
        Upgrade1_Chosen_Event(this, null);
    }
    public event EventHandler Upgrade2_Chosen;
    public void Upgrade2Chosen(object sender, EventArgs e)
    {
        var Upgrade2_Chosen_Event = Upgrade2_Chosen;
        Upgrade2_Chosen_Event(this, null);
    }
    public event EventHandler Upgrade3_Chosen;
    public void Upgrade3Chosen(object sender, EventArgs e)
    {
        var Upgrade3_Chosen_Event = Upgrade3_Chosen;
        Upgrade3_Chosen_Event(this, null);
    }
    public event EventHandler CloseUpgradeScreen_Chosen;
    public void CloseUpgradeScreenChosen(object sender, EventArgs e)
    {
        CloseUpgradeScreen_Chosen(this, null);
    }
}
