using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    private bool gameOver = false;
    private bool gameWon = false;

    [SerializeField]
    private GameObject audioObject;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip success;

    private float delay = 8f;

    private void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        // check if game won
        if (this.GetComponent<RandomizeShoppingList>().everythingCollected())
        {
            Debug.Log("You won!");
            this.GetComponent<SpawnAds>().stopAds();
            this.GetComponent<Timer>().stopTimer();

            // play success sound
            audioSource.clip = success;
            audioSource.Play();
            Debug.Log("Why are you not playing?");
        }
        // game lost if time out
        else if (this.GetComponent<Timer>().timeEnded())
        {
            Debug.Log("You lost!");

            // stop the timer
            this.GetComponent<Timer>().stopTimer();

            // wait a sec so the ads fill up the screen then stop them
            Invoke("stopAds", delay);

        }
		
	}

    private void stopAds()
    {
        this.GetComponent<SpawnAds>().stopAds();
    }
}
