using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GruntState
{
	Initial,
	Moving,
	Attacking,
	Dead
}

public class Grunt : MonoBehaviour
{
	public float moveForce = 0.5f;

	private Rigidbody2D body;
	private GruntState state;
	private float newAngleCooldown = 3.0f;
	private float angle;

	void Start()
    {
		state = GruntState.Moving;
		body = GetComponent<Rigidbody2D>();
	}

	void Update()
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
				var xcomponent = Mathf.Cos(newangle * Mathf.Deg2Rad);
				var ycomponent = Mathf.Sin(newangle * Mathf.Deg2Rad);
				var forcedir = new Vector3(xcomponent, ycomponent, 0.0f);
				transform.rotation = Quaternion.AngleAxis(newangle, Vector3.forward);
				//body.AddForce(transform.forward * 10.0f); // EEH no bueno
				body.AddForce(forcedir * moveForce);
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
}
