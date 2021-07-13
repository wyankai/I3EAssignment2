using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateLocked : MonoBehaviour
{
    public bool dialogueShown = false;
    public GameObject gateLockedDialogue;

    // Update is called once per frame
    public void Interact()
    {
        if (dialogueShown == false)
        {
            gateLockedDialogue.SetActive(true);
            dialogueShown = true;
        }
        else
        {
            gateLockedDialogue.SetActive(false);
            dialogueShown = false;
        }
    }
}
