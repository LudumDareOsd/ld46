using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
	public GameObject startScreen;

	private GameController gameController;

	private void Start()
	{
		gameController = FindObjectOfType<GameController>();
	}

	public void StartGame()
	{
		gameController.StartGame();
		if (startScreen) startScreen.SetActive(false);
	}

	public void Restart()
	{
		gameController.Restart();
	}
}
