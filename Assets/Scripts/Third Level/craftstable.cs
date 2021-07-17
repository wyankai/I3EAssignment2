/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: craftstable

Description of Class: This class will control the craftstable. It allows the player to see how many
                        parts they are left with and crafts the sword when they  collect all the sword parts/

Date Created: 15/06/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class craftstable : MonoBehaviour
{
    private int partsCollected = 0;
    private int partsLeftToCollect;

    public PlayableDirector playableDirector;

    // This is for adding the dialoguePanel and dialogueText so that the player can set it active when interacting with the craftstable
    public GameObject dialoguePanel;
    public Text dialogueText;
    private bool craftstableDialog = false;

    public GameObject Player;
    public GameObject FinalSword;

    public bool crafted = false;
    public GameObject LeftDoor;
    public GameObject RightDoor;
    public GameObject Keyhole;
    public GameObject exclaimationMark;
    public GameObject QuestManager;
    private bool activateOnce = false;
    public bool activateOnceTwo = false;
    public bool activateOnceThree = false;

    private void Update()
    {
        partsLeftToCollect = 5 - partsCollected;
        Text craftsText = dialogueText.GetComponent<Text>();
        craftsText.text = "You have not collected all the parts yet. Parts left to collect : " + partsLeftToCollect;
        if (partsCollected == 5)
        {
            QuestManager.transform.GetComponent<QuestManager>().CollectAllPieces();
            if (activateOnceTwo == false)
            {
                QuestManager.transform.GetComponent<QuestManager>().questNoti();
                activateOnceTwo = true;
            }
        }
    }

    //Adding swordpart
    public void addSwordParts()
    {
        partsCollected += 1;
        Debug.Log("Part Collection :" + partsCollected);
        
    }

    public void Interact()
    {
        //If not all parts are collected, display text
        if (partsLeftToCollect > 0)
        {
            if(craftstableDialog == false)
            {
                dialoguePanel.SetActive(true);
                dialogueText.gameObject.SetActive(true);
                Player.GetComponent<Player>().StopMoving();
                craftstableDialog = true;
                exclaimationMark.SetActive(false);
                //To the complete the quest of interacting with the craftstable
                QuestManager.transform.GetComponent<QuestManager>().InteractWithCraftstable();
                if (activateOnce == false)
                {
                    QuestManager.transform.GetComponent<QuestManager>().questNoti();
                    activateOnce = true;
                }
            }
            else
            {
                dialoguePanel.SetActive(false);
                dialogueText.gameObject.SetActive(false);
                Player.GetComponent<Player>().MoveAgain();
                craftstableDialog = false;
            }   
        }
        else
        {
            //If swordcrafted, clear quest and play audio and animation of the sword getting crafted.
            QuestManager.transform.GetComponent<QuestManager>().InteractWithCraftstable();
            QuestManager.transform.GetComponent<QuestManager>().CollectAllPieces();
            QuestManager.transform.GetComponent<QuestManager>().CraftSword();
            QuestManager.transform.GetComponent<QuestManager>().CollectAllPieces();
            if (activateOnceThree == false)
            {
                QuestManager.transform.GetComponent<QuestManager>().questNoti();
                activateOnceThree = true;
            }
            exclaimationMark.SetActive(false);
            crafted = true;
            playableDirector.Play();
        }
    }
}
