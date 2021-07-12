using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagStand : MonoBehaviour
{
    public bool holdingBag;
    public GameObject bagOnStand;
    public GameObject exclaimationMark;
    public bool dialogueShown = false;
    public GameObject dialogue;

    public void Collect()
    {
        holdingBag = true;
    }
    public void Check()
    {
        if (holdingBag == true)
        {
            Debug.Log("Bag is supposed to appear but idk whats wrong");
            bagOnStand.SetActive(true);
            exclaimationMark.SetActive(false);
        }
        else
        {
           if(dialogueShown == false)
            {
                dialogue.SetActive(true);
                dialogueShown = true;
                exclaimationMark.SetActive(false);
            }
            else
            {
                dialogue.SetActive(false);
                dialogueShown = false;
            }
        }
    }
}
