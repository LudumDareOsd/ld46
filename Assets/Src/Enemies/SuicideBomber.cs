﻿using UnityEngine;

public class SuicideBomber : EnemyBase
{
	public float moveForce = 1.5f;
	private Wall wall;
	public override int scoreWorth => 20;
	public new void Start()
	{
		base.Start();
	}

	public void Update() {
		setAngle();
		body.AddForce(transform.right * moveForce);
		body.velocity = body.velocity * 0.9f;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			wall = collision.gameObject.GetComponent<Wall>();
			wall.takeDamage(5);
			takeDamage(100);
		}
	}

}

