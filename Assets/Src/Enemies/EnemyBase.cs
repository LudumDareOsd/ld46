using UnityEngine;

public class EnemyBase : MonoBehaviour, Enemy
{
	public GameObject corpse;
	public float maxHp = 1f;
	public AudioClip takeDamageAudio;
	public AudioClip deathSoundClip;
	protected EnemyController enemyController;
	protected GameController gameController;
	protected float hp;
	protected float newAngleCooldown = 3.0f;
	protected float angle;
	protected Rigidbody2D body;
	protected bool dead = false;
	public virtual int scoreWorth { get => 10; }

	private AudioSource currentSource;

	public void Start() {
		hp = maxHp;
		enemyController = FindObjectOfType<EnemyController>();
		gameController = FindObjectOfType<GameController>();
		body = GetComponent<Rigidbody2D>();
		var norm = transform.position / -transform.position.magnitude;
		angle = Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	public void Update()
	{
		if (currentSource != null && !currentSource.isPlaying) {
			currentSource = null;
		}
	}

	protected void setAngle() {
		newAngleCooldown += Time.deltaTime;
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

		if (currentSource == null) {
			currentSource = AudioController.instance.PlaySingle(takeDamageAudio, 0.5f);
		}

		if (hp <= 0 && !dead) {
			dead = true; // Stop this triggering multiple times (shotgun or w/e)
			AudioController.instance.PlaySingle(deathSoundClip, 0.5f);
			enemyController.EnemyDied();
			if (corpse) {
				Instantiate(corpse, transform.position, transform.rotation);
			}
			Destroy(gameObject);
			gameController.addToScore(scoreWorth);
		}
	}
}
