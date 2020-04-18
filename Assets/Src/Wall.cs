using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	public bool dead = false;
	public Sprite sprite;
	private float maxHp = 20;
    private float hp = 0;
	private SpriteRenderer spriteRenderer;
	private Collider2D col;
	private HpBar hpBar;

	public void Start()
	{
		hpBar = gameObject.GetComponentInChildren<HpBar>();
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		col = gameObject.GetComponent<Collider2D>();
		hp = maxHp;

		hpBar.SetMaxHp(maxHp);
	}

	public void takeDamage(float damage) {
		if (!dead) {
			hp -= damage;
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
		Destroy(col);
		Destroy(hpBar.gameObject);
	}


}
