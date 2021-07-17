/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: SpeakerUI

Description of Class: This class will control the get the Speaker UI then change the picture/ text/ dialogue according
                        to the Character and Conversation scriptable objects

Date Created: 07/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    public Image portrait;
    public Text fullName;
    public Text dialog;

    private Character speaker;

    /// <summary>
    ///  This is to show the name,and portrait of the character that is talking
    /// </summary>
    public Character Speaker
    {
        get { return speaker;  }
        set
        {
            speaker = value;
            portrait.sprite = speaker.portrait;
            fullName.text = speaker.fullName;
        }
    }

    //This is to show the dialog
    public string Dialog
    {
        set { dialog.text = value; }
    }

    public bool HasSpeaker()
    {
        return speaker != null;
    }

    public bool SpeakerIs(Character character)
    {
        return speaker == character;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
