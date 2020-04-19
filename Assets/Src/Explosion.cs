using UnityEngine;

public class Explosion : MonoBehaviour
{
	public AudioClip clip;

    void Start()
    {
		AudioController.instance.PlaySingle(clip, 0.5f);
    }
}
