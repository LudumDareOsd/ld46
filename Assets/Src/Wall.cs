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

	public void Start()
	{
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		col = gameObject.GetComponent<Collider2D>();
		hp = maxHp;
	}

	public void takeDamage(float damage) {
		if (!dead) {
			hp -= damage;

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
	}


}
