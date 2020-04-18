using UnityEngine;

public class SuicideBomber : MonoBehaviour
{
	private Wall wall;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			wall = collision.gameObject.GetComponent<Wall>();
			wall.takeDamage(5);
			die();
		}
	}

	private void die() {
		Destroy(gameObject);
	}
}
