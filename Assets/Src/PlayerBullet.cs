using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	public float damage = 1f;

	void Start()
	{
		Destroy(gameObject, 2);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10)
		{
			var enemy = collision.gameObject.GetComponent<Enemy>();

			if (enemy != null) {
				enemy.takeDamage(damage);
			}
			Destroy(gameObject);
		}
	}
}
