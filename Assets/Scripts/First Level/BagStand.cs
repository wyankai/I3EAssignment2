/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: BagStand

Description of Class: This class will detect whether or not the player has communicated with the bag stand
                        if not, the script will print the conversation to tell the player on what to do.
                        This class will also help to detect whether or not the player collected the bag and if they did, 
                        the bag stand will "put" the bag on the stand and unlock the door.

Date Created: 11/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagStand : MonoBehaviour
{
    //If the player has collected the bag
    public bool holdingBag;

    //For printting the conversation if the player has not collect the bag yet
    public Conversation conversation;
    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public int activeLineIndex = 0;
    public GameObject Player;


    //For checking to see if the audio has been played and to prevent it from playing again after playing it for the first time
    private  bool soundPlayed = false;
    private bool activateOnce = false;
    private bool activateOnceTwo = false;

    //For refering to object without Raycast
    public GameObject gateOpen;
    public GameObject QuestManager;
    public GameObject bagOnStand;
    public GameObject exclaimationMark;
    public GameObject gate;


    void Start()
    {
        //For the displaying of the dialog
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

    }
    public void Collect()
    {
        //To tell the script that the player has already collect the bag
        holdingBag = true;
    }
    public void Check()
    {
        if (holdingBag == true)
        {
            // If player has the bag, put the bag and open the bag and play the audio
            bagOnStand.SetActive(true);
            exclaimationMark.SetActive(false);
            if (soundPlayed == false)
            {
                GameObject gateAudio = Instantiate(gateOpen, transform.position, Quaternion.identity, null);
                soundPlayed = true;
            }
            gate.SetActive(false);

            // To tell the Quest Manager that the Quest has already been done
            QuestManager.GetComponent<QuestManager>().ClearLevelOne();
            if (activateOnce == false)
            {
                QuestManager.transform.GetComponent<QuestManager>().questNoti();
                activateOnce = true;
            }
        }
        else
        {
            //For the player to interact with the bag stand
            exclaimationMark.SetActive(false);
            Player.GetComponent<Player>().StopMoving();
            AdvanceConversation();
            QuestManager.GetComponent<QuestManager>().InteractStand();
            if (activateOnceTwo == false)
            {
                QuestManager.transform.GetComponent<QuestManager>().questNoti();
                activateOnceTwo = true;
            }
        }
    }

    //For displaying the conversation from the scriptable objects
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
