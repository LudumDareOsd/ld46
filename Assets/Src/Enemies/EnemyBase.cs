using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour, Enemy
{
	public GameObject corpse;
	public float maxHp = 1f;
	protected float hp;
	protected float newAngleCooldown = 3.0f;
	protected float angle;
	protected Rigidbody2D body;

	public void Start() {
		hp = maxHp;
		body = GetComponent<Rigidbody2D>();
	}

	protected void setAngle() {
		var norm = transform.position / -transform.position.magnitude; // inverted normal
		if (newAngleCooldown >= 3.0f)
		{
			angle = Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg;
			angle += Random.Range(-30f, 30f);
			newAngleCooldown -= 3.0f - Random.Range(0f, 3.0f);
		}
		var currentAngle = transform.localEulerAngles.z;
		var newangle = Mathf.LerpAngle(currentAngle, angle, Time.deltaTime);
		transform.rotation = Quaternion.AngleAxis(newangle, Vector3.forward);
	}

	public void takeDamage(float damage)
	{
		hp -= damage;

		if (hp <= 0) {
			Instantiate(corpse, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
