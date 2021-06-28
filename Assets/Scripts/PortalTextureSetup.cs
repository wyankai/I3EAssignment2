using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{

	//public Camera cameraA;
	public Camera cameraB;

	//public Material cameraMatA;
	public Material cameraMatB;

	// Use this for initialization
	void Start()
	{
		//if (cameraA.targetTexture != null)
		//{
			//cameraA.targetTexture.Release();
		//}
		//cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		//cameraMatA.mainTexture = cameraA.targetTexture;

		//Removing texture for camera B if there is any texture
		if (cameraB.targetTexture != null)
		{
			cameraB.targetTexture.Release();
		}

		//Set new texture for camera B.
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 0);
		cameraMatB.mainTexture = cameraB.targetTexture;
	}

}
