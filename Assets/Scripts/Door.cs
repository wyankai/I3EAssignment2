using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    private bool doorOpen = false;

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
        }
        else
        {
            doorOpen = false;
            Debug.Log("Door is closed");
        }
    }


}
