using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneScript : MonoBehaviour
{
    public GameObject Player;

    void CutsceneStart()
    {
        Player.GetComponent<Player>().StopMoving();
    }

    void CutsceneEnd(){
        Player.GetComponent<Player>().MoveAgain();
    }
}
