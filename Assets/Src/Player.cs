using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Texture2D cursor;
	public GameController gameController;
	private Rigidbody2D body;
	private Weapon weapon;
	private float stopfireCount = 0;

	public void Start()
	{
		body = GetComponent<Rigidbody2D>();
		weapon = GetComponentInChildren<Weapon>();
		gameController = FindObjectOfType<GameController>();
		setCursorToCrosshair();
	}

	void Update()
    {
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		body.AddForce(5 * new Vector2(moveHorizontal, moveVertical));
		body.velocity = body.velocity * 0.9f;

		var mouseScreenPosition = Input.mousePosition;
		mouseScreenPosition.z = transform.position.z;
		var mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
		var angle = AngleBetweenTwoPoints(mouseWorldSpace, transform.position);
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (Input.GetButton("Fire1") && !gameController.pauseInput)
		{
			weapon.Fire(Time.deltaTime);
			stopfireCount = 0;
		}
		else {
			stopfireCount += Time.deltaTime;

			if (stopfireCount >= 0.1f) {
				weapon.StopFire();
			}
		}
	}
	public void setCursorToCrosshair()
	{
		var cursorHotspot = new Vector2(cursor.width / 2, cursor.height / 2);
		Cursor.SetCursor(cursor, cursorHotspot, CursorMode.Auto);
	}
	public void UpgradeWeapon()
	{
		weapon.UpgradeWeapon();
	}
	public int PlayerWeaponLevel { get => weapon.WeaponLevel; }
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
