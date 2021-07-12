/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: PortalTextureSetup

Description of Class: This class will setup the portal during the run time so that 
					  the portal's texture will fit the player's playing screen

Date Created: 27/06/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{

	public Camera cameraA;
	public Camera cameraB;

	public Camera cameraC;
	public Camera cameraD;

	public Camera cameraE;
	public Camera cameraF;


	public Material cameraMatA;
	public Material cameraMatB;

	public Material cameraMatC;
	public Material cameraMatD;

	public Material cameraMatE;
	public Material cameraMatF;

	// Use this for initialization
	void Update()
	{
		if (cameraA.targetTexture != null)
		{
			cameraA.targetTexture.Release();
		}
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatA.mainTexture = cameraA.targetTexture;


		//Removing texture for camera B if there is any texture
		if (cameraB.targetTexture != null)
		{
			cameraB.targetTexture.Release();
		}
		//Set new texture for camera B.
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatB.mainTexture = cameraB.targetTexture;


		//Removing texture for camera C if there is any texture
		if (cameraC.targetTexture != null)
		{
			cameraC.targetTexture.Release();
		}
		//Set mew texture for camera C
		cameraC.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatC.mainTexture = cameraC.targetTexture;

		//Removing texture for camera D if there is any texture
		if (cameraD.targetTexture != null)
		{
			cameraD.targetTexture.Release();
		}
		//Set mew texture for camera D
		cameraD.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatD.mainTexture = cameraD.targetTexture;

		//Removing texture for camera E if there is any texture
		if (cameraE.targetTexture != null)
		{
			cameraE.targetTexture.Release();
		}
		//Set mew texture for camera E
		cameraE.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatE.mainTexture = cameraE.targetTexture;

		//Removing texture for camera D if there is any texture
		if (cameraF.targetTexture != null)
		{
			cameraF.targetTexture.Release();
		}
		//Set mew texture for camera F
		cameraF.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
		cameraMatF.mainTexture = cameraF.targetTexture;
	}

}
