using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    private bool gameOver = false;
    private bool gameWon = false;

    private bool startDelay = false;
    private float delay = 8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // check if game won
        if (this.GetComponent<RandomizeShoppingList>().everythingCollected())
        {
            Debug.Log("You won!");
            this.GetComponent<SpawnAds>().stopAds();
            this.GetComponent<Timer>().stopTimer();
        }
        // game lost if time out
        else if (this.GetComponent<Timer>().timeEnded())
        {
            Debug.Log("You lost!");

            // stop the timer
            this.GetComponent<Timer>().stopTimer();

            // wait a sec so the ads fill up the screen then stop them
            startDelay = true;

            if (delay < 0)
            {
                this.GetComponent<SpawnAds>().stopAds();
            }
        }

        if (startDelay) delay -= Time.deltaTime;
		
	}
}
