/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: FinalDoor

Description of Class: This class will control the final door interactions.

Date Created: 15/07/2021
******************************************************************************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FinalDoor : MonoBehaviour
{
    //For display message
    public Conversation conversation;
    public GameObject speakerLeft;
    public GameObject speakerRight;
    public Camera CutsceneCamera;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public int activeLineIndex = 0;
    public GameObject Player;
    public bool playerInRange = false;

    public bool swordCollected = false;
    public PlayableDirector playableDirector;
    // Start is called before the first frame update
    void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

    }

    // Swor Collected
    public void SwordCollected()
    {
        swordCollected = true;
    }

    public void Interact()
    {
        //If sword is not collected, display text to tell the player to craft the sword/ Remind the players they need to take the sword
        if(swordCollected == false)
        {
            Player.GetComponent<Player>().StopMoving();
            Debug.Log("Player has stoppped moving");
            AdvanceConversation();

            if (Input.GetKey(KeyCode.Escape))
            {
                Player.GetComponent<Player>().MoveAgain();
            }
        }
        else
        {
            //Else the game will end
        }
        
    }

    void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;
            Player.GetComponent<Player>().MoveAgain();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;
            Player.GetComponent<Player>().MoveAgain();
        }
    }

    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (speakerUILeft.SpeakerIs(character))
        {
            SetDialog(speakerUILeft, speakerUIRight, line.text);
        }
        else
        {
            SetDialog(speakerUIRight, speakerUILeft, line.text);
        }
    }

    void SetDialog(
        SpeakerUI activeSpeakerUI,
        SpeakerUI inactiveSpeakerUI,
        string text)
    {
        activeSpeakerUI.Dialog = text;
        activeSpeakerUI.Show();
        inactiveSpeakerUI.Hide();
    }
}
