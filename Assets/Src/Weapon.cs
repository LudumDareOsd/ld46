using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	public GameObject bullet;
	public AudioClip pistolClip;
	public AudioClip shotgunClip;
	public AudioClip machineGunClip;

	private AudioSource source; 
	private Collider2D weaponColl;
	private float fireTime = 0f;
	private int type = 0, maxtype = 0;

	public void Start() {
		weaponColl = GetComponentInParent<Collider2D>();
		source = AudioController.instance.createSource().GetComponent<AudioSource>();

		source.clip = machineGunClip;
		source.volume = 0.5f;
		source.spatialBlend = 0;
		source.dopplerLevel = 0;
		source.spread = 0;
		source.pitch = 1f;
	}

	public void Update() {
		fireTime -= Time.deltaTime;
		if (Input.GetKey(KeyCode.Alpha1) || Input.GetButton("JoyB_A")) {
			type = 0;
		} else if ((Input.GetKey(KeyCode.Alpha2) || Input.GetButton("JoyB_X")) && maxtype >= 1) {
			type = 1;
		} else if ((Input.GetKey(KeyCode.Alpha3) || Input.GetButton("JoyB_Y")) && maxtype >= 2) {
			type = 2;
		}
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

	public void StopFire() {
		if (source.isPlaying)
		{
			source.Stop();
		}
	}

	private void pistol() {
		spawnBullet(transform.position, 0, 2f);
		AudioController.instance.PlaySingle(pistolClip, 0.1f);

		fireTime = 0.7f;
	}

	private void shotgun()
	{
		spawnBullet(transform.position, 5f, 1f);
		spawnBullet(transform.position, 2f, 1f);
		spawnBullet(transform.position, 0, 1f);
		spawnBullet(transform.position, -2f, 1f);
		spawnBullet(transform.position, -5f, 1f);

		AudioController.instance.PlaySingle(shotgunClip, 0.1f);

		fireTime = 1.2f;
	}

	private void lmg()
	{
		spawnBullet(transform.position, Random.Range(-4f, 4f), 0.6f);

		if (!source.isPlaying) {
			source.Play();
		}

		fireTime = 0.1f;
	}

	private void spawnBullet(Vector3 position, float angle, float damage) {
		var rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, angle));
		var bulletInstance = Instantiate(bullet, position, rotation);
		bulletInstance.GetComponent<PlayerBullet>().damage = damage;
		var bulletBody = bulletInstance.GetComponent<Rigidbody2D>();
		bulletBody.velocity = (bulletInstance.transform.right) * 2f;
	}

	public void UpgradeWeapon()
	{
		type++;
		maxtype++;
	}
	public int WeaponLevel { get => type; }
}
