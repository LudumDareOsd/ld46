using UnityEngine;

public class SuicideBomber : MonoBehaviour, Enemy
{

	private float moveForce = 1.38f;
	private Rigidbody2D body;
	private float newAngleCooldown = 3.0f;
	private float angle;
	private Wall wall;

	private void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		newAngleCooldown += Time.deltaTime;

		var norm = transform.position / -transform.position.magnitude; // inverted normal
		if (newAngleCooldown >= 3.0f)
		{
			angle = Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg;
			angle += Random.Range(-20f, 20f);
			newAngleCooldown -= 3.0f - Random.Range(0f, 3.0f);
		}
		var currentAngle = transform.localEulerAngles.z;
		var newangle = Mathf.LerpAngle(currentAngle, angle, Time.deltaTime);
		transform.rotation = Quaternion.AngleAxis(newangle, Vector3.forward);
		body.AddForce(transform.right * moveForce);
		body.velocity = body.velocity * 0.9f;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Wall"))
		{
			wall = collision.gameObject.GetComponent<Wall>();
			wall.takeDamage(5);
			die();
		}
	}

	public void takeDamage(float damage)
	{
		// trigger explosion
		Destroy(gameObject);
	}

	private void die() {
		Destroy(gameObject);
	}
}
