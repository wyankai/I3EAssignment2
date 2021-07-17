/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: BagPuzzle

Description of Class: This class will destroy the collectibles once it is collected

Date Created: 4/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPuzzle : MonoBehaviour
{
    //This is to get the audio as well as the bagstand object so that we can link to the bag stand script
    public GameObject bagStand;
    public GameObject collectAudio;

    public void Collect()
    {
        //Play sound and destroy the object
        GameObject collectedAudio = Instantiate(collectAudio, transform.position, Quaternion.identity, null);
        Destroy(gameObject);

        //Telling the bag stand script that the object is collected
        bagStand.GetComponent<BagStand>().Collect();
        
    }
}
