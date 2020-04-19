using UnityEngine;

public class DecayCorpse : MonoBehaviour
{
	private SpriteRenderer spriteRenderer;
	private float counter = 0.0f, completeTime = 100.0f;
	private bool finished = false;

	void Start()
    {
		spriteRenderer = GetComponent<SpriteRenderer>();
		if (!spriteRenderer) finished = true;
	}

	void LateUpdate()
    {
		if (!finished)
		{
			counter += Time.deltaTime;
			var col = 1.0f - (counter / completeTime);
			spriteRenderer.color = new Color(col, col, col, col);
			if (counter > completeTime)
			{
				Destroy(gameObject);
				finished = true;
			}
		}
	}
}
