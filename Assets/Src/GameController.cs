using System;
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
		enemyController.StartWave(wave, WaveFinished);
	}

	void Update()
    {
		switch (status)
		{
			case GameStatus.Start:
				break;
			case GameStatus.Wave:
				break;
			case GameStatus.Upgrade:
				break;
			default:
				break;
		}
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
		if (favor > 0)
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
		status = GameStatus.Wave;
		hudController.CloseUpgradeScreen();
	}
	public void addToScore(int addAmount)
	{
		score += addAmount;
		hudController.SetScore(score);
	}
	public void BeginNextWave()
	{
		wave++;
		enemyController.StartWave(wave, WaveFinished);
		hudController.SetWave(wave);
	}
	public void WaveFinished()
	{
		favor++;
		hudController.showUpgradeScreen(favor, Player.PlayerWeaponLevel, Walls[0].WallDefenseLevel);
		Invoke("BeginNextWave", 5f);
	}

	internal enum GameStatus
	{
		Start,
		Wave,
		Upgrade
	}
}
