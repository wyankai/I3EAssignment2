/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)
[Adapted from Mr Elyas's Script]

Name of Class: PortalCamera

Description of Class: This class will set up the camera material for the portal so that it will follow the player's camera. 
					  (Provide a more smooth texture)

Date Created: 20/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{

	public Transform playerCamera;
	public Transform portal;
	public Transform otherPortal;

	// Update is called once per frame
	void Update()
	{
		//Get the portal camera position to be the same as player's position
		Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
		transform.position = portal.position + playerOffsetFromPortal;

		float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

		//To get the camera to rotate as the player's camera rotate
		Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
		Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
		transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
	}
}
