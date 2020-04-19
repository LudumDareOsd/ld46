using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public ScoreText ScoreText;
    public UpgradeScreen UpgradeScreen;
    public WaveTexts WaveTexts;

	void Start()
    {
        if (UpgradeScreen != null)
        {
            UpgradeScreen.Upgrade1_Clicked += Upgrade1Chosen;
            UpgradeScreen.Upgrade2_Clicked += Upgrade2Chosen;
            UpgradeScreen.Upgrade3_Clicked += Upgrade3Chosen;
            UpgradeScreen.CloseUpgradeScreenClicked += CloseUpgradeScreenChosen;
            UpgradeScreen.SummonTheUncleanOne_Clicked += SummonTheUncleanOneChosen;
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

    public void showUpgradeScreen(int favor, int playerweaponlevel, int walldefenselevel, int weaponupgradecost, int wallupgradecost, int wallrestorecost)
    {
        UpgradeScreen.ShowUpgradeScreen(favor, playerweaponlevel, walldefenselevel, weaponupgradecost, wallupgradecost, wallrestorecost);
    }
    public void UpdateFavorLeft(int favor)
    {
        UpgradeScreen.updateFavorLeft(favor);
    }
    public void updatePlayerWeaponLevel(int weaponlevel)
    {
        UpgradeScreen.updatePlayerWeaponLevel(weaponlevel);
    }
    public void updateWallDefenseLevel(int walldefenselevel)
    {
        UpgradeScreen.updateWallDefenseLevel(walldefenselevel);
    }
    public void updateWallUpgradeCost(int wallupgradecost)
    {
        UpgradeScreen.updateWallUpgradeCost(wallupgradecost);
    }
    public void updateWeaponUpgradeCost(int weaponupgradecost)
    {
        UpgradeScreen.updateWeaponUpgradeCost(weaponupgradecost);
    }
    public void updateWallRestoreCost(int wallrestorecost)
    {
        UpgradeScreen.updateWallRestoreCost(wallrestorecost);
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

    public event EventHandler SummonTheUncleanOne_Chosen;
    public void SummonTheUncleanOneChosen(object sender, EventArgs e)
    {
        SummonTheUncleanOne_Chosen(this, null);
    }
}
