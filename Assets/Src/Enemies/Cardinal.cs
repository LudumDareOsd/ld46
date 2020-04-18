using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cardinal : EnemyBase
{
	public float moveForce = 1.5f;

	private CardinalState state;
	private float attackCooldown = 0f;
	private Wall wall;

	public new void Start()
	{
		base.Start();
		state = CardinalState.Moving;
	}

	public void Update()
	{
		switch (state)
		{
			case CardinalState.Moving:
				setAngle();
				body.AddForce(transform.right * moveForce);
				break;
			case CardinalState.Attacking:
				if (wall.dead)
				{
					state = CardinalState.Moving;
				}
				attackCooldown -= Time.deltaTime;
				if (attackCooldown <= 0)
				{
					wall.takeDamage(2);
					attackCooldown = 1f;
				}
				break;
		}

		body.velocity = body.velocity * 0.9f;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			wall = collision.gameObject.GetComponent<Wall>();
			state = CardinalState.Attacking;
		}
	}

	internal enum CardinalState
	{
		Initial,
		Moving,
		Attacking,
		Dead
	}
}
