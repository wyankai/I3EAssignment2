/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: NPC

Description of Class: This class will allow the player to interact with the NPCs and display chat text

Date Created: 27/06/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject Player;
    public bool playerInRange = false;
    void Update()
    {
        Interact();
    }

    public void PlayerInRange()
    {
        playerInRange = true;
    }

    public void PlayerNotInRange()
    {
        playerInRange = false;
    }

    public void Interact()
    {
        if (playerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player.GetComponent<Player>().StopMoving();
                Debug.Log("Player has stoppped moving");

            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Player.GetComponent<Player>().MoveAgain();
            }
        }
        else
        {
            Player.GetComponent<Player>().MoveAgain();
        }
    }
}
