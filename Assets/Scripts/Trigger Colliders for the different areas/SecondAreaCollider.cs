using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondAreaCollider : MonoBehaviour
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
            CameraD.enabled = true;
            CameraE.enabled = true;
            CameraF.enabled = false;

            planeA.SetActive(false);
            planeB.SetActive(false);
            planeC.SetActive(false);
            planeD.SetActive(true);
            planeE.SetActive(true);
            planeF.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
            Debug.Log(" Player is in second area");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
            Debug.Log(" Player has left the second area");
        }
    }
}
