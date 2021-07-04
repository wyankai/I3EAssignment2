/******************************************************************************
Author: Syakir(S10204929) and Yankai(S10206089)

Name of Class: Collectibles

Description of Class: This class will destroy the collectibles once it is collected

Date Created: 4/07/2021
******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
   

    public void Collect()
    {
        Destroy(gameObject);
    }
}
