using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody2D body;

	public void Start()
	{
		body = GetComponent<Rigidbody2D>();
	}

	void Update()
    {
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		Debug.Log(moveVertical);
		body.AddForce(5 * new Vector2(moveHorizontal, moveVertical));
		body.velocity = body.velocity * 0.9f;


		var positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		var mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

		var angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

		transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
