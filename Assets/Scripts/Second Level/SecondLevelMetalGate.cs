using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondLevelMetalGate : MonoBehaviour
{
    //For animation
    public Animator gateAnimator;
    public Animator dragonAnimator;
    public Animator krakenAnimator;
    public Animator phoenixAnimator;

    //For display message
    public Conversation conversation;
    public GameObject speakerLeft;
    public GameObject speakerRight;

    private SpeakerUI speakerUILeft;
    private SpeakerUI speakerUIRight;

    public int activeLineIndex = 0;
    public GameObject Player;
    public bool playerInRange = false;

    //For buttons
    private bool dragonPressed = false;
    private bool krakenPressed = false;
    private bool phoenixPressed = false;
    private bool firstButtonCorrect = false;
    private bool secondButtonCorrect = false;
    private int buttonPressed = 0;
    private bool gateOpen = false;

    public GameObject gateOpenAudio;

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
        if (buttonPressed == 3)
        {
            correctElseRest();
        }
        gateAnimator.SetBool("GateOpen", gateOpen);
        dragonAnimator.SetBool("dragonPressed", dragonPressed);
        phoenixAnimator.SetBool("phoenixPressed", phoenixPressed);
        krakenAnimator.SetBool("krakenPressed", krakenPressed);
    }

    //For adding the audio to the animation
    public void gateSound()
    {
        GameObject gateAudio = Instantiate(gateOpenAudio, transform.position, Quaternion.identity, null);
    }

    //Dragon Pressed
    public void pressDragon()
    {
        //This if statement prevent the button to be pressed again if its already pressed.
        if(dragonPressed == false)
        {
            dragonPressed = true;
            buttonPressed += 1;
            Debug.Log("Dragon Button is pressed");
            if (krakenPressed == false && phoenixPressed == false)
            {
                firstButtonCorrect = true;
                Debug.Log("First Button is correct");
            }
            else
            {
                firstButtonCorrect = false;
                Debug.Log("First Button is wrong");
            }
        }
        else
        {
            Debug.Log("This button is already pressed");
        }
    }

    //Kraken Pressed
    public void pressKraken()
    {
        //This if statement prevent the button to be pressed again if its already pressed.
        if(krakenPressed == false)
        {
            krakenPressed = true;
            buttonPressed += 1;
            Debug.Log("Kraken Button is pressed");
            if (dragonPressed == true && phoenixPressed == false)
            {
                secondButtonCorrect = true;
                Debug.Log("Second Button is correct");
            }
            else
            {
                secondButtonCorrect = false;
                Debug.Log("Second Button is wrong");
            }
        }
        else
        {
            Debug.Log("This button is already pressed");
        }

    }

    //Phoenix Pressed
    public void pressPhoenix()
    {
        if(phoenixPressed == false)
        {
            phoenixPressed = true;
            buttonPressed += 1;
            Debug.Log("Phoenix Button is pressed");
        }
        else
        {
            Debug.Log("This button is already pressed");
        }

    }

    //Checking if the buttons are pressed in the correct order
    public void correctElseRest()
    {
        //if button pressed in correct order, open
        if(firstButtonCorrect == true && secondButtonCorrect == true)
        {
            gateOpen = true;
            Debug.Log("Buttons are pressed in the correct order");
        }
        //else reset the buttons
        else
        {
            dragonPressed = false;
            krakenPressed = false;
            phoenixPressed = false;
            firstButtonCorrect = false;
            secondButtonCorrect = false;
            buttonPressed = 0;
            Debug.Log("Buttons are pressed in the incorrect order");
        }
    }

    //For diplaying locked message
    public void Interact()
    {
        Player.GetComponent<Player>().StopMoving();
        Debug.Log("Player has stoppped moving");
        AdvanceConversation();

        if (Input.GetKey(KeyCode.Escape))
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
