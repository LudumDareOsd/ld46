using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject bullet;
	private Collider2D weaponColl;
	private Rigidbody2D parentBody;
	private float cooldown = 0.5f;
	private float fireTime = 0f;

	public void Start() {
		weaponColl = GetComponentInParent<Collider2D>();
		parentBody = GetComponentInParent<Rigidbody2D>();
	}

	public void Update() {
		fireTime -= Time.deltaTime;
	}

	public void Fire(float delta) {
		if (fireTime <= 0f) {
			var bulletInstance = Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
			var bulletBody = bulletInstance.GetComponent<Rigidbody2D>();
			bulletBody.velocity = parentBody.transform.up * 5f;

			fireTime = cooldown;
		}
	}
}
