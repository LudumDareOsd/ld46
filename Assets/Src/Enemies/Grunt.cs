using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : MonoBehaviour, Enemy
{
	void Start()
    {
        
    }

    void Update()
    {
		var norm = transform.position / transform.position.magnitude;
		transform.position += new Vector3(Random.Range(-0.01f, 0.01f), Random.Range(-0.01f, 0.01f), 0);
		transform.position -= norm / 400;
	}

	public void takeDamage(float damage)
	{
		
	}
}
