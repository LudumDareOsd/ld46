using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D body;
	private Weapon weapon;

	public void Start()
	{
		body = GetComponent<Rigidbody2D>();
		weapon = GetComponentInChildren<Weapon>();
	}

	void Update()
    {
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		body.AddForce(5 * new Vector2(moveHorizontal, moveVertical));
		body.velocity = body.velocity * 0.9f;

		var positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		var mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		var angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen) + 90f;

		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

		if (Input.GetButton("Fire1")) {
			weapon.Fire(Time.deltaTime);
		}
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
