/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: Door

Description of Class: This class will open/ close the door when the door is being interacted with. This class also help to set up the animation of the door

Date Created: 27/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public bool doorOpen = false;
    public GameObject doorAudio;
    public GameObject closeAudio;

    private void Update()
    {
        animator.SetBool("doorOpen", doorOpen);
    }
    
    
    public void Open()
    {
        if(doorOpen == false)
        {
            doorOpen = true;
            Debug.Log("Door is opened");
            GameObject doorOpenAudio = Instantiate(doorAudio, transform.position, Quaternion.identity, null);
        }
        else
        {
            doorOpen = false;
            Debug.Log("Door is closed");
            GameObject doorCloseAudio = Instantiate(closeAudio, transform.position, Quaternion.identity, null);
        }
    }


}
