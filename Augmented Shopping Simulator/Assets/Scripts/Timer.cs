using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    [SerializeField]
    private GameObject timerText;

    [SerializeField]
    private GameObject audioObject;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip countDown;

    private bool playSoundOnce = true;

    private float timer = 60f;

    private string minutes, seconds;

    private bool GameDone = false;

	// Use this for initialization
	void Start () {
        audioSource = audioObject.GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!GameDone)
        {
            timer -= Time.deltaTime;

            // format it to display
            minutes = Mathf.Floor(timer / 60).ToString("00");
            seconds = (timer % 60).ToString("00");


            timerText.GetComponent<TextMeshProUGUI>().text = minutes + ":" + seconds;
        }

        // start count down timer sound
        if (timer <= 11f && playSoundOnce)
        {
            audioSource.clip = countDown;
            audioSource.Play();
            //Debug.Log("Playing timer sound");

            playSoundOnce = false;
        }

        if (!playSoundOnce && this.GetComponent<EndGame>().isGameOver())
        {
            audioSource.Stop();
        }
            
	}

    public bool timeEnded()
    {
        if (timer <= 0) return true;
        return false;
    }

    public void stopTimer()
    {
        GameDone = true;
        timerText.GetComponent<TextMeshProUGUI>().text = "00:00";
    }
}
