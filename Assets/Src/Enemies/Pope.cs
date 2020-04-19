using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pope : EnemyBase
{
	public float moveForce = 0.4f;

	private PopeState state;
	private float attackCooldown = 0f;
	private Wall wall;
	public override int scoreWorth => 100;
	public new void Start()
	{
		base.Start();
		state = PopeState.Moving;
	}

	public void Update()
	{
		switch (state)
		{
			case PopeState.Moving:
				setAngle();
				body.AddForce(transform.right * moveForce);
				break;
			case PopeState.Attacking:
				if (wall.dead)
				{
					state = PopeState.Moving;
				}
				attackCooldown -= Time.deltaTime;
				if (attackCooldown <= 0)
				{
					wall.takeDamage(5);
					attackCooldown = 2f;
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
			state = PopeState.Attacking;
		}
	}

	internal enum PopeState
	{
		Initial,
		Moving,
		Attacking,
		Dead
	}
}
