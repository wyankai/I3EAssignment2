/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: SwordPart

Description of Class: This class will destory the sword part and send the information that it
                    is collected to the craftstable

Date Created: 13/07/2021
******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPart : MonoBehaviour
{
    public GameObject craftstable;

    // Start is called before the first frame update
    public void collect()
    {
        Destroy(gameObject);
        craftstable.transform.GetComponent<craftstable>().addSwordParts();
    }
}
