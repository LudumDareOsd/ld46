using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pope : EnemyBase
{
	public float moveForce = 0.4f;

	private PopeState state;
	private float attackCooldown = 0f;
	private Attackable target;
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
				if (target.dead)
				{
					state = PopeState.Moving;
				}
				attackCooldown -= Time.deltaTime;
				if (attackCooldown <= 0)
				{
					target.takeDamage(5);
					attackCooldown = 2f;
				}
				break;
		}

		body.velocity = body.velocity * 0.9f;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Attackable"))
		{
			target = collision.gameObject.GetComponent<Attackable>();
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
