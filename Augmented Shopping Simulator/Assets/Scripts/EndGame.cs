using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    private bool gameOver = false;
    private bool gameWon = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // check if game won
        if (this.GetComponent<CartTrigger>().winner())
        {
            Debug.Log("You won!");
        }
        // game lost if time out
        else if (this.GetComponent<Timer>().timeEnded())
        {
            Debug.Log("You lost!");
        }
		
	}
}
