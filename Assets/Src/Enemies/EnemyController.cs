using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Per våg hur många fiender av varje typ
 * Spawna i samma ordning varje gång, men olika spawnpoints
 * Trigger när det är klart 
 * Något som gör det svårare per våg
 */

public class EnemyController : MonoBehaviour
{
	public GameObject enemyContainer;
	public GameObject gruntPrefab, suiciderPrefab;
	public GameObject[] spawnPoints;

	private float totalWaveTime = 10.0f;
	private float spawnDelay = 3.0f;

	//private HudController hud;
	private float waveTimer = 0.0f;
	private float spawnTimer = 0.0f;

	void Start()
    {
		//gruntPrefab = (GameObject)Resources.Load("Prefabs/Enemies/grunt", typeof(GameObject));
		//Debug.Log(enemyContainer);
		//Debug.Log(gruntPrefab);
		SpawnGrunt();
    }

    void Update()
    {

	}

	void SpawnGrunt()
	{
		var spawnpoint = Random.Range(0, spawnPoints.Length);
		var pos = spawnPoints[spawnpoint].transform.position;
		var grunt = Instantiate(gruntPrefab, pos, Quaternion.identity);
		grunt.transform.SetParent(enemyContainer.transform);
	}

	void SpawnSuicider()
	{
		var spawnpoint = Random.Range(0, spawnPoints.Length);
		var pos = spawnPoints[spawnpoint].transform.position;
		var suicider = Instantiate(suiciderPrefab, pos, Quaternion.identity);
		suicider.transform.SetParent(enemyContainer.transform);
	}

	public void StartWave(int newWave)
	{
		var isBosswave = newWave % 10 == 0;
		Debug.Log("Spawning wave " + newWave + " Boss: " + isBosswave);
		waveTimer = spawnTimer = 0.0f;
		spawnDelay = 1.0f;
		StartCoroutine(SpawnWave());
	}

	// every 2 seconds perform the print()
	private IEnumerator SpawnWave()
	{
		while (true)
		{
			waveTimer += .1f;
			spawnTimer += .1f;
			if (spawnTimer > spawnDelay)
			{
				if (Random.Range(0, 3) > 1) {
					SpawnSuicider();
				} else {
					SpawnGrunt();
				}
				spawnTimer -= spawnDelay;
			}
			if (waveTimer > totalWaveTime)
			{
				waveTimer -= totalWaveTime;
			}
			yield return new WaitForSeconds(.1f);
		}
	}
}
