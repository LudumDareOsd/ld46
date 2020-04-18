using UnityEngine;

public class Grunt : EnemyBase
{
	public float moveForce = 0.5f;

	private GruntState state;
	private float attackCooldown = 0f;
	private Wall wall;

	public new void Start()
	{
		base.Start();
		state = GruntState.Moving;
	}

	private void Update()
	{
		switch (state)
		{
			case GruntState.Moving:
				setAngle();
				body.AddForce(transform.right * moveForce);
				break;
			case GruntState.Attacking:
				if (wall.dead) {
					state = GruntState.Moving;
				}

				attackCooldown -= Time.deltaTime;
				if (attackCooldown <= 0) {
					wall.takeDamage(1);
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
			state = GruntState.Attacking;
		}
	}

	internal enum GruntState
	{
		Initial,
		Moving,
		Attacking,
		Dead
	}
}
