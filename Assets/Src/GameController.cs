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
	private int WeaponUpgradeCost { get => Player.PlayerWeaponLevel + 1; }
	private int WallUpgradeCost { get => Walls[0].WallDefenseLevel; }
	private int WallRestoreCost { get => 1; }

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
			hudController.UpdateFavorLeft(favor);
			hudController.updateWeaponUpgradeCost(WeaponUpgradeCost);
			hudController.updatePlayerWeaponLevel(Player.PlayerWeaponLevel);
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
			hudController.UpdateFavorLeft(favor);
			hudController.updateWallDefenseLevel(Walls[0].WallDefenseLevel);
			hudController.updateWallUpgradeCost(WallUpgradeCost);
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
			hudController.UpdateFavorLeft(favor);
			hudController.updateWallRestoreCost(WallRestoreCost);
			if (favor == 0)
			{
				hudController.CloseUpgradeScreen();
			}
		}
	}
	public void CloseUpgradeScreen(object sender, EventArgs e)
	{
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
		hudController.showUpgradeScreen(favor, Player.PlayerWeaponLevel, Walls[0].WallDefenseLevel, WeaponUpgradeCost, WallUpgradeCost, WallRestoreCost);
		Invoke("BeginNextWave", 5f);
	}
	

	internal enum GameStatus
	{
		Start,
		Wave,
		Upgrade
	}
}
