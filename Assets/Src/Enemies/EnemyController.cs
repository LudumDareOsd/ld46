using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public GameObject enemyContainer;
	public GameObject gruntPrefab;
	public GameObject[] spawnPoints;

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
		waveTimer += Time.deltaTime;
		spawnTimer += Time.deltaTime;
		if (spawnTimer > 5.0f) {
			SpawnGrunt();
			spawnTimer -= 5.0f;
		}
	}

	void SpawnGrunt()
	{
		var spawnpoint = Random.Range(0, spawnPoints.Length);
		var pos = spawnPoints[spawnpoint].transform.position;
		var grunt = Instantiate(gruntPrefab, pos, Quaternion.identity);
		grunt.transform.SetParent(enemyContainer.transform);
	}
}
