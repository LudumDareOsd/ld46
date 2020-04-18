using System.Collections;
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

	private float totalWaveTime = 15.0f;
	private float spawnDelay = 3.0f;

	private float waveTimer = 0.0f;
	private float spawnTimer = 0.0f;
	private int currentMob = 0;
	private int aliveMobs = 0;

	void Start()
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

	public void StartWave(int newWave, System.Action callback)
	{
		var isBosswave = newWave % 5 == 0;
		waveTimer = spawnTimer = 0.0f;
		currentMob = aliveMobs = 0;
		spawnDelay = 3.0f - (2.0f * (newWave / 10)); // Wave 1 = 3sec, wave 10 = 1sec between spawns

		Debug.Log("Spawning wave " + newWave + " Bosswave: " + isBosswave);
		StartCoroutine(SpawnWave(callback));
	}

	private IEnumerator SpawnWave(System.Action callback = null)
	{
		while (true)
		{
			waveTimer += .1f;
			spawnTimer += .1f;
			if (waveTimer > totalWaveTime && aliveMobs <= 0)
			{
				callback();
				yield break;
			}

			if (waveTimer <= totalWaveTime && spawnTimer > spawnDelay)
			{
				currentMob++;
				aliveMobs++;
				if (currentMob % 3 == 0) {
					SpawnSuicider();
				} else {
					SpawnGrunt();
				}
				spawnTimer -= spawnDelay;
			}
			yield return new WaitForSeconds(.1f);
		}
	}

	public void EnemyDied()
	{
		aliveMobs--;
	}
}
