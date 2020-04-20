using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Texture2D cursor;
	public GameController gameController;
	public int PlayerWeaponLevel { get => weapon.WeaponLevel; }
	private Rigidbody2D body;
	private Weapon weapon;
	private float stopfireCount = 0;
	private float angle = 0;
	private Vector3 mousepos = Vector3.zero;

	public void Start()
	{
		body = GetComponent<Rigidbody2D>();
		weapon = GetComponentInChildren<Weapon>();
		gameController = FindObjectOfType<GameController>();
		setCursorToCrosshair();
	}

	void Update()
    {
		Vector3 inputDirection = Vector3.zero;
		inputDirection.x = Input.GetAxisRaw("Joy X");
		inputDirection.y = Input.GetAxisRaw("Joy Y");

		var useController = inputDirection.magnitude > 0.2f;
		var useMouse = (mousepos != Input.mousePosition);

		if (!gameController.pauseInput) {
			if (useMouse)
			{
				mousepos = Input.mousePosition;
				var mouseWorldSpace = Camera.main.ScreenToWorldPoint(mousepos);
				angle = AngleBetweenTwoPoints(mouseWorldSpace, transform.position);
			}
			else if (useController)
			{
				angle = AngleBetweenTwoPoints(transform.position, transform.position + inputDirection);
			}
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			var moveHorizontal = Input.GetAxis("Horizontal");
			var moveVertical = Input.GetAxis("Vertical");

			body.AddForce(5 * new Vector2(moveHorizontal, moveVertical));
		}

		body.velocity = body.velocity * 0.9f;

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

	private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}
}
