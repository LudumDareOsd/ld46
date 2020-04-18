using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		int resWidth = Screen.width;
		int resHeight = Screen.height;

		RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
		Camera.main.targetTexture = rt; //Create new renderTexture and assign to camera
		Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false); //Create new texture

		Camera.main.Render();

		RenderTexture.active = rt;
		screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0); //Apply pixels from camera onto Texture2D

		Camera.main.targetTexture = null;
		RenderTexture.active = null; //Clean
		Destroy(rt); //Free memory
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
