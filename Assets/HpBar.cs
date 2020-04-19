using UnityEngine;

public class HpBar : MonoBehaviour
{
	public float maxHp = 10f;
	public GameObject hpBar;

	public void Start()
	{
		SetHp(maxHp);
	}

	public void SetMaxHp(float hp)
	{
		maxHp = hp;
	}

	public void SetHp(float hp) {
		hpBar.transform.localScale = new Vector3(hp / maxHp, 1, 1);
	}

}
