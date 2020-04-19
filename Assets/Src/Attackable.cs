using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
	public bool dead = false;
	public Sprite sprite;
	public int WallDefenseLevel { get => (int)defenseLevel; }

	protected float maxHp = 20;
	protected float hp = 0;
	protected SpriteRenderer spriteRenderer;
	protected Collider2D col;
	protected HpBar hpBar;
	protected float defenseLevel = 1f;

	private Sprite original;

	public void Start()
	{
		hpBar = gameObject.GetComponentInChildren<HpBar>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		col = gameObject.GetComponent<Collider2D>();
		hp = maxHp;
		hpBar.SetMaxHp(maxHp);
		original = spriteRenderer.sprite;
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

	protected void restore() {
		dead = false;
		spriteRenderer.sprite = original;
		spriteRenderer.sortingLayerName = "ForeGround";
		col.enabled = true;
		hpBar.gameObject.SetActive(true);
	}

	private void die()
	{
		dead = true;
		spriteRenderer.sprite = sprite;
		spriteRenderer.sortingLayerName = "Background";
		col.enabled = false;
		hpBar.gameObject.SetActive(false);
	}
}
