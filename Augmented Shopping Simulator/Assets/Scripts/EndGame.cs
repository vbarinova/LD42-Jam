using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class EndGame : MonoBehaviour {

    private bool gameOver = false;
    private bool gameWon = false;

    [SerializeField]
    private AudioSource audioSource;

    public Canvas GameOver;
    public Canvas GameWin;
    public GameObject fpscontroller;

    private float delay = 8f;

    private bool m_endGame = false;

    private void Awake()
    {

        m_endGame = false;
        audioSource.enabled = false;
        GameOver.enabled = false;
        GameWin.enabled = false;
        fpscontroller.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;
        fpscontroller.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(true);

    }

    // Update is called once per frame
    void FixedUpdate () {

        // check if game won
        if (!m_endGame && this.GetComponent<RandomizeShoppingList>().everythingCollected())
        {
            Debug.Log("You won!");
            this.GetComponent<SpawnAds>().stopAds();
            this.GetComponent<Timer>().stopTimer();

            // play success sound

            audioSource.enabled = true;
            GameWin.enabled = true;
            fpscontroller.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;
            fpscontroller.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
            m_endGame = true;
        }
        // game lost if time out
        else if (!m_endGame && this.GetComponent<Timer>().timeEnded())
        {
            Debug.Log("You lost!");
            m_endGame = true;
            // stop the timer
            this.GetComponent<Timer>().stopTimer();

            // wait a sec so the ads fill up the screen then stop them
            Invoke("stopAds", delay);
            GameOver.enabled = true;
            fpscontroller.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;
            fpscontroller.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);

        }
		
	}

    private void stopAds()
    {
        this.GetComponent<SpawnAds>().stopAds();
    }
}
