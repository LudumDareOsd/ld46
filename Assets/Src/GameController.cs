using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public int maxWave = 10;

	private int wave = 1;
	private GameStatus status = GameStatus.Start;
	private EnemyController enemyController;
	private HudController hudController;

    void Start()
    {
		enemyController = FindObjectOfType<EnemyController>();
		hudController = FindObjectOfType<HudController>();
		enemyController.StartWave(wave);
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

	internal enum GameStatus
	{
		Start,
		Wave,
		Upgrade
	}
}
