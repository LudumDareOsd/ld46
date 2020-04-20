using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
	private CustomCounter counter;

    void Awake()
    {
		counter = gameObject.GetComponent<CustomCounter>();
	}

    public void UpdateScoreText(int score)
	{
		counter.SetNumber(score.ToString());
	}
}
