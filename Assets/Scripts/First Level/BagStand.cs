using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagStand : MonoBehaviour
{
    public bool holdingBag;

    public GameObject bagOnStand;
    public GameObject exclaimationMark;
    public GameObject gate;

    public bool dialogueShown = false;
    public GameObject dialogue;
    public GameObject Player;

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
            gate.SetActive(false);
        }
        else
        {
           if(dialogueShown == false)
            {
                dialogue.SetActive(true);
                dialogueShown = true;
                exclaimationMark.SetActive(false);
                Debug.Log("Player should stop moving");
                Player.GetComponent<Player>().StopMoving();
            }
            else
            {
                dialogue.SetActive(false);
                dialogueShown = false;
                Player.GetComponent<Player>().MoveAgain();
            }
        }
    }
}
