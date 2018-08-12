using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

    private bool collected = false;

    public bool isCollected()
    {
        return collected;
    }

    public void hasBeenCollected()
    {
        collected = true;
    }

    
}
