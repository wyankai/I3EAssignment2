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

    private void Start()
    {
        //dialoguePanel.SetActive(false);
        //dialogueText.gameObject.SetActive(false);
    }

    public void addSwordParts()
    {
        partsCollected += 1;
        Debug.Log("Part Collection :" + partsCollected);
    }

    public void Interact()
    {
        partsLeftToCollect = 5 - partsCollected;
        if (partsLeftToCollect > 0)
        {
            //dialogueText.text = "You have not collected all the parts yet. Parts left to collect : " + partsLeftToCollect;

        }
        else
        {

        }
    }
}
