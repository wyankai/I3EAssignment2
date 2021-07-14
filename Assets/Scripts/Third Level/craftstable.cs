using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craftstable : MonoBehaviour
{
    private int partsCollected = 0;
    // Start is called before the first frame update
    public void addSwordParts()
    {
        partsCollected += 1;
        Debug.Log("Part Collection :" + partsCollected);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
