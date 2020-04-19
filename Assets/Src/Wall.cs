using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	public bool dead = false;
	public Sprite sprite;
	private float defenseLevel = 1f;
	private float maxHp = 20;
    private float hp = 0;
	private SpriteRenderer spriteRenderer;
	private Collider2D col;
	private HpBar hpBar;
	public int WallDefenseLevel { get => (int)defenseLevel; }
	public void Start()
	{
		hpBar = gameObject.GetComponentInChildren<HpBar>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		col = gameObject.GetComponent<Collider2D>();
		hp = maxHp;

		hpBar.SetMaxHp(maxHp);
	}
	public void increaseDefenseLevel()
	{
		defenseLevel += 1f;
	}
	public void restoreAllHP()
	{
		hp = maxHp;
		hpBar.SetHp(hp);
	}
	public void takeDamage(float damage) {
		if (!dead) {
			hp -= damage / defenseLevel;
			hpBar.SetHp(hp);

			if (hp <= 0)
			{
				die();
			}
		}
	}

	private void die() {
		dead = true;
		spriteRenderer.sprite = sprite;
		col.enabled = false;
		hpBar.gameObject.SetActive(false);
	}
}
