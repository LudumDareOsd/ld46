﻿using UnityEngine;

public class Wall : Attackable
{
	public new void Start()
	{
		base.Start();
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
}
