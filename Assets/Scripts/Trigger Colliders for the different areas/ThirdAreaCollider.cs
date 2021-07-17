/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: ThirdAreaCollider

Description of Class: This class will detect if the player is in the first area then disable cameras that are not needed

Date Created: 13/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdAreaCollider : MonoBehaviour
{
    // To disable the cameras and planes while in this area so that the game would not lag too much during its runtime(PART 1)
    public Camera CameraA;
    public Camera CameraB;
    public Camera CameraC;
    public Camera CameraD;
    public Camera CameraE;
    public Camera CameraF;

    public GameObject planeA;
    public GameObject planeB;
    public GameObject planeC;
    public GameObject planeD;
    public GameObject planeE;
    public GameObject planeF;

    private bool playerIsOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping == true)
        {
            CameraA.enabled = false;
            CameraB.enabled = false;
            CameraC.enabled = false;
            CameraD.enabled = false;
            CameraE.enabled = false;
            CameraF.enabled = true;

            planeA.SetActive(false);
            planeB.SetActive(false);
            planeC.SetActive(false);
            planeD.SetActive(false);
            planeE.SetActive(false);
            planeF.SetActive(true);
        }
    }

    //Detect if the player is in the area
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
