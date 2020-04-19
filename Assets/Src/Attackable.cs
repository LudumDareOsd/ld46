using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
	public bool dead = false;
	public Sprite sprite;
	protected float maxHp = 20;
	protected float hp = 0;
	protected SpriteRenderer spriteRenderer;
	protected Collider2D col;
	protected HpBar hpBar;
	protected float defenseLevel = 1f;
	public int WallDefenseLevel { get => (int)defenseLevel; }

	public void Start()
	{
		hpBar = gameObject.GetComponentInChildren<HpBar>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		col = gameObject.GetComponent<Collider2D>();
		hp = maxHp;
		hpBar.SetMaxHp(maxHp);
	}

	public virtual void takeDamage(float damage)
	{
		if (!dead)
		{
			hp -= damage / defenseLevel;
			hpBar.SetHp(hp);

			if (hp <= 0)
			{
				die();
			}
		}
	}

	private void die()
	{
		dead = true;
		spriteRenderer.sprite = sprite;
		col.enabled = false;
		hpBar.gameObject.SetActive(false);
	}
}
