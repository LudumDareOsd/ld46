using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyController : MonoBehaviour
{
	public GameObject enemyContainer;
	public GameObject gruntPrefab, suiciderPrefab, cardinalPrefab, popePrefab;
	public GameObject[] spawnPoints;
	public AudioClip winWaveSound;

	public GameObject globalLight, altarLight;

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
		currentMob = 0;
		totalMobs = 3 + (newWave * 2);
		aliveMobs = totalMobs;
		spawnDelay = totalWaveTime / (totalMobs + 1);

		Debug.Log("Spawning wave:" + newWave + " Mobs: " + totalMobs + " Bosswave:" + isBosswave);
		StartCoroutine(SpawnWave(callback, isBosswave));
	}

	public float WaveProgress()
	{
		return 1.0f - Mathf.Min((float)aliveMobs / (float)totalMobs, 1.0f);
	}

	public float WaveProgressContinuous()
	{
		return Mathf.Min(waveTimer / 30f, 1.0f);
	}

	private IEnumerator SpawnWave(System.Action callback = null, bool bosswave = false)
	{
		while (true)
		{
			globalLight.GetComponent<Light2D>().intensity = Mathf.Max(1.0f - WaveProgressContinuous(), 0.3f);

			waveTimer += .1f;
			spawnTimer += .1f;
			if (waveTimer > totalWaveTime && aliveMobs <= 0)
			{
				AudioController.instance.PlaySingle(winWaveSound, 0.5f);

				yield return new WaitForSeconds(4f);
				globalLight.GetComponent<Light2D>().intensity = 1.0f;
				altarLight.GetComponent<Light2D>().intensity = 0.0f;
				callback();
				yield break;
			}

			if (waveTimer <= totalWaveTime && spawnTimer > spawnDelay)
			{
				currentMob++;

				if (bosswave && currentMob % totalMobs == 0) { // last mob on bosswave is pope?
					SpawnEnemy(popePrefab);
				} else if (currentMob % 3 == 0) {
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
		altarLight.GetComponent<Light2D>().intensity = WaveProgress();
	}
}
