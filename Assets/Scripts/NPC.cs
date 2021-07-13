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
    public GameObject exclaimationMark;
    public Conversation conversation;

    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public int activeLineIndex = 0;
    public GameObject Player;
    public bool playerInRange = false;

    void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

    }

    void Update()
    {
        Interact();
    }

    public void PlayerInRange()
    {
        playerInRange = true;
        Debug.Log("Player is in range");
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
                exclaimationMark.SetActive(false);
                Player.GetComponent<Player>().StopMoving();
                Debug.Log("Player has stoppped moving");
                AdvanceConversation();
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