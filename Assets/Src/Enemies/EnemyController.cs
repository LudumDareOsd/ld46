using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public GameObject enemyContainer;
	public GameObject gruntPrefab;
	public GameObject[] spawnPoints;
	public float totalWaveTime = 10.0f;
	public float spawnDelay = 3.0f;

	//private HudController hud;
	private float waveTimer = 0.0f;
	private float spawnTimer = 0.0f;
	private int wave = 1;

	void Start()
    {
		//gruntPrefab = (GameObject)Resources.Load("Prefabs/Enemies/grunt", typeof(GameObject));
		//Debug.Log(enemyContainer);
		//Debug.Log(gruntPrefab);
		SpawnGrunt();
    }

    void Update()
    {
		waveTimer += Time.deltaTime;
		spawnTimer += Time.deltaTime;
		if (spawnTimer > spawnDelay) {
			SpawnGrunt();
			spawnTimer -= spawnDelay;
		}
	}

	void SpawnGrunt()
	{
		var spawnpoint = Random.Range(0, spawnPoints.Length);
		var pos = spawnPoints[spawnpoint].transform.position;
		var grunt = Instantiate(gruntPrefab, pos, Quaternion.identity);
		grunt.transform.SetParent(enemyContainer.transform);
	}

	void StartWave(int newWave)
	{
		wave = newWave;
	}
}
