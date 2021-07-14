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
