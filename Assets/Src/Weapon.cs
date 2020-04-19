using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject bullet;
	private Collider2D weaponColl;
	private float fireTime = 0f;
	private int type = 0;


	public void Start() {
		weaponColl = GetComponentInParent<Collider2D>();
	}

	public void Update() {
		fireTime -= Time.deltaTime;
	}

	public void Fire(float delta) {
		if (fireTime <= 0f) {
			switch (type) {
				case 0:
					pistol();
					break;

				case 1:
					shotgun();
					break;

				case 2:
					lmg();
					break;
			}
		}
	}

	private void pistol() {
		spawnBullet(transform.position, 0);

		fireTime = 0.5f;
	}

	private void shotgun()
	{
		spawnBullet(transform.position, 5f);
		spawnBullet(transform.position, 2f);
		spawnBullet(transform.position, 0);
		spawnBullet(transform.position, -2f);
		spawnBullet(transform.position, -5f);

		fireTime = 1f;
	}

	private void lmg()
	{
		spawnBullet(transform.position, 0);

		fireTime = 0.1f;
	}

	private void spawnBullet(Vector3 position, float angle) {
		var rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, angle));
		var bulletInstance = Instantiate(bullet, position, rotation);
		var bulletBody = bulletInstance.GetComponent<Rigidbody2D>();
		bulletBody.velocity = (bulletInstance.transform.right) * 3f;

	}

	public void UpgradeWeapon()
	{
		type++;
	}
	public int WeaponLevel { get => type; }
}
