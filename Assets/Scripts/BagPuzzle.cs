/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: Collectibles

Description of Class: This class will destroy the collectibles once it is collected

Date Created: 4/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagPuzzle : MonoBehaviour
{
    public bool holdingBag ;
    public GameObject bagOnStand;
    public GameObject bagStand;

    public void Collect()
    {
        Debug.Log("Bag is collected");
        holdingBag = true;
        if (gameObject != bagStand)
        {
            Destroy(gameObject);
        }
        else
        {
            bagStand.GetComponent<BagPuzzle>().Collect();
        }
        
        
    }
    public void Check()
    {
        if (holdingBag == true)
        {
            Debug.Log("Bag is supposed to appear but idk whats wrong");
            bagOnStand.SetActive(true);
        }
        else
        {
            Debug.Log("You havent collect the bag yet");
        }
    }
}
