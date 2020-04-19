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
	private int type = 0;

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
		spawnBullet(transform.position, 0);
		AudioController.instance.PlaySingle(pistolClip, 0.3f);

		fireTime = 0.5f;
	}

	private void shotgun()
	{
		spawnBullet(transform.position, 5f);
		spawnBullet(transform.position, 2f);
		spawnBullet(transform.position, 0);
		spawnBullet(transform.position, -2f);
		spawnBullet(transform.position, -5f);

		AudioController.instance.PlaySingle(shotgunClip, 0.3f);

		fireTime = 1f;
	}

	private void lmg()
	{
		spawnBullet(transform.position, 0);

		if (!source.isPlaying) {
			source.Play();
		} 

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
