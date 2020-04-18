using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Texture2D cursor;
	private Rigidbody2D body;
	private Weapon weapon;

	public void Start()
	{
		body = GetComponent<Rigidbody2D>();
		weapon = GetComponentInChildren<Weapon>();
		var cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
		Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
	}

	void Update()
    {
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		body.AddForce(5 * new Vector2(moveHorizontal, moveVertical));
		body.velocity = body.velocity * 0.9f;

		var upAxis = new Vector3(0, 0, -1);
		var mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = transform.position.z;
		var mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
		transform.LookAt(mouseWorldSpace, upAxis);
		transform.eulerAngles = new Vector3(0, 0, -transform.eulerAngles.z);
		transform.rotation *= Quaternion.Euler(new Vector3(0, 0, 180f));

		if (Input.GetButton("Fire1")) {
			weapon.Fire(Time.deltaTime);
		}
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
