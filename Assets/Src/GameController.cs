﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public int maxWave = 10;
	private int score = 0; 
	private int wave = 1;
	private int favor = 0;
	private Wall[] Walls;
	private Player Player;
	private GameStatus status = GameStatus.Start;
	private EnemyController enemyController;
	private HudController hudController;

    void Start()
    {
		enemyController = FindObjectOfType<EnemyController>();
		hudController = FindObjectOfType<HudController>();
		Walls = FindObjectsOfType<Wall>();
		Player = FindObjectOfType<Player>();
		hudController.Upgrade1_Chosen += UpgradeWeapon;
		hudController.Upgrade2_Chosen += UpgradeWalls;
		hudController.Upgrade3_Chosen += RestoreWalls;
		hudController.CloseUpgradeScreen_Chosen += CloseUpgradeScreen;
		hudController.SetWave(wave);
		hudController.SetScore(score);
		enemyController.StartWave(wave);
	}

	void Update()
    {
		switch (status)
		{
			case GameStatus.Start:
				break;
			case GameStatus.Wave:
				hudController.SetWave(wave);
				break;
			case GameStatus.Upgrade:
				hudController.showUpgradeScreen(favor, Player.PlayerWeaponLevel, Walls[0].WallDefenseLevel);
				break;
			default:
				break;
		}
	}

	public void changeToUpgrade()
	{
		status = GameStatus.Upgrade;
	}
	public void UpgradeWeapon(object sender, EventArgs e)
	{
		if (favor >= Player.PlayerWeaponLevel + 1 && Player.PlayerWeaponLevel < 2)
		{
			favor -= Player.PlayerWeaponLevel + 1;
			Player.UpgradeWeapon();
			status = GameStatus.Start;
			hudController.UpdateFavorLeft(favor);
			if (favor == 0)
			{
				hudController.CloseUpgradeScreen();
			}
		}
	}
	public void UpgradeWalls(object sender, EventArgs e)
	{
		if (favor >= Walls[0].WallDefenseLevel)
		{
			favor -= Walls[0].WallDefenseLevel;
			foreach (var wall in Walls)
			{
				wall.increaseDefenseLevel();
			}
			status = GameStatus.Start;
			hudController.UpdateFavorLeft(favor);
			if (favor == 0)
			{
				hudController.CloseUpgradeScreen();
			}
		}
	}
	public void RestoreWalls(object sender, EventArgs e)
	{
		if(favor > 0)
		{
			favor -= 1;
			foreach (var wall in Walls)
			{
				wall.restoreAllHP();
			}
			status = GameStatus.Start;
			hudController.UpdateFavorLeft(favor);
			if (favor == 0)
			{
				hudController.CloseUpgradeScreen();
			}
		}
	}
	public void CloseUpgradeScreen(object sender, EventArgs e)
	{
		status = GameStatus.Start;
		hudController.CloseUpgradeScreen();
	}
	internal enum GameStatus
	{
		Start,
		Wave,
		Upgrade
	}
}
