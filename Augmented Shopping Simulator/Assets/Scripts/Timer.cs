using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {

    [SerializeField]
    private GameObject timerText;

    private float timer = 60f;

    private string minutes, seconds;

    private bool GameDone = false;

	// Use this for initialization
	void Start () {
		
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
