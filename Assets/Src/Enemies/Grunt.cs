using UnityEngine;

public class Grunt : MonoBehaviour, Enemy
{
	public float moveForce = 0.5f;

	private Rigidbody2D body;
	private GruntState state;
	private float newAngleCooldown = 3.0f;
	private float angle;

	private void Start()
	{
		state = GruntState.Moving;
		body = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		newAngleCooldown += Time.deltaTime;

		switch (state)
		{
			case GruntState.Moving:
				var norm = transform.position / -transform.position.magnitude; // inverted normal
				if (newAngleCooldown >= 3.0f)
				{
					angle = Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg;
					angle += Random.Range(-30f, 30f);
					newAngleCooldown -= 3.0f - Random.Range(0f, 3.0f);
				}
				var currentAngle = transform.localEulerAngles.z;
				var newangle = Mathf.LerpAngle(currentAngle, angle, Time.deltaTime);
				transform.rotation = Quaternion.AngleAxis(newangle, Vector3.forward);
				body.AddForce(transform.right * moveForce); // EEH no bueno
				break;
			case GruntState.Attacking:
				break;
		}
		body.velocity = body.velocity * 0.9f;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log(collision.gameObject);
		if (collision.gameObject.CompareTag("Wall"))
		{
			Debug.Log(collision.gameObject);
			state = GruntState.Attacking;
		}
	}

	public void takeDamage(float damage)
	{
		Destroy(gameObject);
	}

	internal enum GruntState
	{
		Initial,
		Moving,
		Attacking,
		Dead
	}
}
