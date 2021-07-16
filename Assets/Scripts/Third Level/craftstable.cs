using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class craftstable : MonoBehaviour
{
    private int partsCollected = 0;
    private int partsLeftToCollect;

    // This is for adding the dialoguePanel and dialogueText so that the player can set it active when interacting with the craftstable
    public GameObject dialoguePanel;
    public Text dialogueText;
    private bool craftstableDialog = false;

    public GameObject Player;
    public bool crafted = false;

    private void Start()
    {
    }

    private void Update()
    {
        partsLeftToCollect = 5 - partsCollected;
        Text craftsText = dialogueText.GetComponent<Text>();
        craftsText.text = "You have not collected all the parts yet. Parts left to collect : " + partsLeftToCollect;
    }

    public void addSwordParts()
    {
        partsCollected += 1;
        Debug.Log("Part Collection :" + partsCollected);
    }

    public void Interact()
    {
        if (partsLeftToCollect > 0)
        {
            if(craftstableDialog == false)
            {
                Debug.Log("dialogue is supposed to set active but idk what wrong");
                dialoguePanel.SetActive(true);
                dialogueText.gameObject.SetActive(true);
                Player.GetComponent<Player>().StopMoving();
                craftstableDialog = true;
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
            crafted = true;
        }
    }
}
