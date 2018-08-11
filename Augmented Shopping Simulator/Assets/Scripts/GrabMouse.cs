using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabMouse : MonoBehaviour {

    [SerializeField]
    private Sprite unClicked;

    [SerializeField]
    private Sprite clicked;

	// Use this for initialization
	void Start () {
        this.GetComponent<Image>().sprite = unClicked;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<Image>().sprite = clicked;
        }

        if (Input.GetMouseButtonUp(0))
        {
            this.GetComponent<Image>().sprite = unClicked;
        }
		
	}
}
