using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
	void Start()
	{
		Destroy(gameObject, 2);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 9)
		{
			// collision.gameObject.GetComponent<Car>().TakeDamage(10 + Random.Range(-2, 2));
			Destroy(gameObject);
		}
	}
}
