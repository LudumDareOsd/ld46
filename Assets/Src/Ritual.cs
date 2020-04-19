using UnityEngine;

public class Ritual : MonoBehaviour
{
	public EnemyController enemyController;

	public Sprite[] frames;
	private SpriteRenderer sr;

	public void Start()
	{
		sr = gameObject.GetComponent<SpriteRenderer>();
	}

	public void Update()
	{
		var frameInt = Mathf.FloorToInt((frames.Length-1) * Mathf.Clamp01(enemyController.WaveProgress()));
		sr.sprite = frames[frameInt];
	}
}
