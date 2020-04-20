using UnityEngine;
using UnityEngine.UI;

public class CustomCounter : MonoBehaviour
{
	public GameObject[] positions;
	public Sprite[] numbers;

	private string number = "0";

	private void Awake()
	{
		Refresh();
	}

	public void SetNumber(string num)
	{
		number = num;
		Refresh();
	}

	private void Refresh()
	{
		for (var i = 0; i < positions.Length; i++)
		{
			if (i < number.Length)
			{
				if(!positions[i].activeSelf) positions[i].SetActive(true);
				var letter = number[i];
				positions[i].GetComponent<Image>().sprite = numbers[(int)char.GetNumericValue(letter)];
			}
			else
			{
				positions[i].SetActive(false);
			}
		}
	}
}
