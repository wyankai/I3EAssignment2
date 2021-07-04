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
