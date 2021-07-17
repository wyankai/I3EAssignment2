/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)
[Adapted from Mr Elyas's Script]

Name of Class: QuestManager

Description of Class: This class will control the quest displayed at the UI on the screen

Date Created: 17/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public Text questText;
    public GameObject questUI;

    //If the tasks are done
    private bool inFirstArea = false;
    private bool talkToNPC = false;
    private bool interactWithStand = false;
    private bool clearAreaOne = false;
    private bool findGraveyard = false;
    private bool clearAreaTwo = false;
    private bool interactWithCraftstable = false;
    private bool collectAllPieces = false;
    private bool swordCrafted = false;


    public GameObject Notification;

    // Update is called once per frame

    //Printing of the task for the quest
    void Update()
    {
        if(talkToNPC == true)
        {
            questUI.SetActive(true);
        }
        if(inFirstArea == false)
        {
            questText.text = " Go To the First Trial";
        }
        if ((interactWithStand == false)&& (inFirstArea == true))
        {
            questText.text = "Check out the stand in the room";
        }
        if ((clearAreaOne == false) && (interactWithStand == true))
        {
            questText.text = "Solve the puzzle in the room";
            
        }
        if ((findGraveyard == false) && (clearAreaOne == true))
        {
            questText.text = "Find the graveyard in the forest";
        }
        if ((clearAreaTwo == false) && (findGraveyard == true))
        {
            questText.text = "Solve the puzzle in this area";
        }
        if ((interactWithCraftstable == false) && (clearAreaTwo == true))
        {
            questText.text = "Interact with the craftstable";
        }
        if ((collectAllPieces == false) && (interactWithCraftstable == true))
        {
            questText.text = "Find the sword pieces";
        }
        if ((swordCrafted == false) && (collectAllPieces == true)&&(interactWithCraftstable == true))
        {
            questText.text = "Craft the sword";
        }


    }

    public void TalkedToNPC()
    {
        talkToNPC = true;
    }

    public void InFirstArea()
    {
        inFirstArea = true;
    }

    public void InteractStand()
    {
        interactWithStand = true;
    }
    public void ClearLevelOne()
    {
        clearAreaOne = true;
    }
    public void FindGraveyard()
    {
        findGraveyard = true;
    }
    public void ClearLevelTwo()
    {
        clearAreaTwo = true;
    }
    public void InteractWithCraftstable()
    {
        interactWithCraftstable = true;
    }
    public void CollectAllPieces()
    {
        collectAllPieces = true;
    }
    public void CraftSword()
    {
        swordCrafted = true;
    }


    public void questNoti()
    {
        GameObject collectedAudio = Instantiate(Notification, transform.position, Quaternion.identity, null);
    }
}
