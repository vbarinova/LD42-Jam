using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour {

    public GameObject TextObj;
    private Text myText;
    private float fadeTime = 10f;
    private bool displayInfo = false;

	// Use this for initialization
	void Start () {
        myText = TextObj.GetComponent<Text>();
        myText.color = Color.clear;  // set text inivible
    }
	
	// Update is called once per frame
	void Update () {

        FadeText();

	}

    // similar to on trigger enter
    private void OnMouseOver()
    {
        displayInfo = true;
    }

    private void OnMouseExit()
    {
        displayInfo = false;
    }

    private void FadeText()
    {
        if (displayInfo)
        {
            myText.text = this.tag;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
        }
        else
        {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }
}
