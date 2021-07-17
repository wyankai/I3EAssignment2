/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)
[Adapted from Mr Elyas's Script]

Name of Class: Sword

Description of Class: This class will collect the sword and pass this information to another script

Date Created: 17/07/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject FinalDoor;

    // Update is called once per frame
    public void Collect()
    {
        Destroy(gameObject);
        FinalDoor.transform.GetComponent<FinalDoor>().SwordCollected();
    }
}
