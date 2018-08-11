using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedEnd : MonoBehaviour {

    private bool reachedEnd = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        reachedEnd = true;
    }

    // PUBLIC FUNCTIONS
    public bool gameOver()
    {
        return reachedEnd;
    }
}
