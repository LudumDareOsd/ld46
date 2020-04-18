using UnityEngine;

public class Ritual : MonoBehaviour
{
	public EnemyController enemyController;

	public Sprite frame1;
	public Sprite frame2;
	public Sprite frame3;
	public Sprite frame4;
	public Sprite frame5;
	public Sprite frame6;
	public Sprite frame7;
	private Sprite sprite;
	private SpriteRenderer sr;

	private float[] parts = new float[8];

	public void Start()
	{
		parts[0] = 0f;
		parts[1] = 0.125f;
		parts[2] = 0.25f;
		parts[3] = 0.375f;
		parts[4] = 0.5f;
		parts[5] = 0.625f;
		parts[6] = 0.75f;
		parts[7] = 1f;

		sr = gameObject.GetComponent<SpriteRenderer>();
	}

	public void Update()
	{
		float partDone = 0f;

		if (partDone < parts[1])
		{
		} else if (partDone > parts[1] && partDone < parts[2])
		{
			sprite = frame1;
		}
		else if (partDone > parts[2] && partDone < parts[3])
		{
			sprite = frame2;
		}
		else if (partDone > parts[3] && partDone < parts[4])
		{
			sprite = frame3;
		}
		else if (partDone > parts[4] && partDone < parts[5])
		{
			sprite = frame4;
		}
		else if (partDone > parts[5] && partDone < parts[6])
		{
			sprite = frame5;
		}
		else if (partDone > parts[6] && partDone < parts[7])
		{
			sprite = frame6;
		}
		else {
			sprite = frame7;
		}

		sr.sprite = sprite;
	}
}
