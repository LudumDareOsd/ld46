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
	public GameObject gruntPrefab, suiciderPrefab, cardinalPrefab;
	public GameObject[] spawnPoints;

	private float totalWaveTime = 15.0f;
	private float spawnDelay = 3.0f;

	private float waveTimer = 0.0f;
	private float spawnTimer = 0.0f;
	private int currentMob = 0;
	private int aliveMobs = 0;
	private int totalMobs = 0;

	void SpawnEnemy(GameObject prefab)
	{
		var spawnpoint = Random.Range(0, spawnPoints.Length);
		var pos = spawnPoints[spawnpoint].transform.position;
		var mob = Instantiate(prefab, pos, Quaternion.identity);
		mob.transform.SetParent(enemyContainer.transform);
	}

	public void StartWave(int newWave, System.Action callback)
	{
		var isBosswave = newWave % 5 == 0;
		waveTimer = spawnTimer = 0.0f;
		currentMob = aliveMobs = 0;
		totalMobs = 3 + newWave;
		spawnDelay = totalWaveTime / (totalMobs + 1);
		//spawnDelay = 3.0f - (2.0f * (newWave / 10)); // Wave 1 = 3sec, wave 10 = 1sec between spawns
		Debug.Log("Spawning wave:" + newWave + " Mobs: " + totalMobs + " Bosswave:" + isBosswave);
		StartCoroutine(SpawnWave(callback));
	}

	public float WaveProgress()
	{
		return Mathf.Min(waveTimer / totalWaveTime, 1.0f);
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
					SpawnEnemy(suiciderPrefab);
				} else if (currentMob % 4 == 0) {
					SpawnEnemy(cardinalPrefab);
				} else {
					SpawnEnemy(gruntPrefab);
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
