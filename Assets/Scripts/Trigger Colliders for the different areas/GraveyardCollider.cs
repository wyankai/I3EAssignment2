/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: GraveyardCollider

Description of Class: This class will detect if the player has reached the graveyard.

Date Created: 17/07/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardCollider : MonoBehaviour
{
    public GameObject QuestManager;
    private bool activateOnce = false;

    //If player is at the graveyard then clear task
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            QuestManager.transform.GetComponent<QuestManager>().FindGraveyard();
            if (activateOnce == false)
            {
                QuestManager.transform.GetComponent<QuestManager>().questNoti();
                activateOnce = true;
            }
        }
    }

}
