using UnityEngine;

public class IgnoreRotation : MonoBehaviour
{
	public Vector3 position = new Vector3(0, -0.18f, 0);
	Quaternion rotation;

	void Awake()
	{
		rotation = transform.rotation;
		//position = transform.localPosition;
	}

	void LateUpdate()
	{
		var wantedPos = transform.parent.position + position;
		transform.rotation = Quaternion.identity;
		transform.position = wantedPos;
	}
}
