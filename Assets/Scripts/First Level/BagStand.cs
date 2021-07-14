using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagStand : MonoBehaviour
{
    public bool holdingBag;

    public GameObject bagOnStand;
    public GameObject exclaimationMark;
    public GameObject gate;

    public Conversation conversation;
    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public int activeLineIndex = 0;
    public GameObject Player;
    public bool playerInRange = false;

    public GameObject gateOpen;

    void Start()
    {
        speakerUILeft = speakerLeft.GetComponent<SpeakerUI>();
        speakerUIRight = speakerRight.GetComponent<SpeakerUI>();

        speakerUILeft.Speaker = conversation.speakerLeft;
        speakerUIRight.Speaker = conversation.speakerRight;

    }
    public void Collect()
    {
        holdingBag = true;
    }
    public void Check()
    {
        if (holdingBag == true)
        {
            Debug.Log("Bag is placed");
            bagOnStand.SetActive(true);
            exclaimationMark.SetActive(false);
            GameObject gateAudio = Instantiate(gateOpen, transform.position, Quaternion.identity, null);
            gate.SetActive(false);
        }
        else
        {
            exclaimationMark.SetActive(false);
            Player.GetComponent<Player>().StopMoving();
            Debug.Log("Player has stoppped moving");
            AdvanceConversation();

            if (Input.GetKey(KeyCode.Escape))
            {
                Player.GetComponent<Player>().MoveAgain();
            }
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
