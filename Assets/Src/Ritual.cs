using UnityEngine;

public class Ritual : Attackable
{
	public GameController gameController;
	public EnemyController enemyController;
	public Sprite[] frames;

	public new void Start()
	{
		base.Start();
		maxHp = 30.0f;
		hp = maxHp;
		hpBar.SetMaxHp(maxHp);
	}

	public void Update()
	{
		var frameInt = Mathf.FloorToInt((frames.Length-1) * Mathf.Clamp01(enemyController.WaveProgress()));
		spriteRenderer.sprite = frames[frameInt];
	}

	public override void takeDamage(float damage)
	{
		if (!dead)
		{
			hp -= damage;
			hpBar.SetHp(hp);

			if (hp <= 0)
			{
				dead = true;
				gameController.Die();
			}
		}
	}
}
