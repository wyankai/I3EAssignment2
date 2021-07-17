/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: DialogDisplay

Description of Class: This class will show the ending dialogue
Date Created: 17/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingDialogue : MonoBehaviour
{
     public Conversation conversation;

    //Getting the UI for the Speaker on the Left and the Speaker on the Right
    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public int activeLineIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AdvanceConversation();
        }
    }

    //Uses loop to prints the current line then add on to the index to print the next line
    void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            //This is to increase the indext to print lines in the Dialog "array"
            activeLineIndex += 1;
        }
        else
        {
            SceneManager.LoadScene("Credits");
            speakerUILeft.Hide();
            speakerUIRight.Hide();
            activeLineIndex = 0;
        }
    }

    //For displaying of the lines in the conversation.
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
