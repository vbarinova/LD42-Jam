using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {

        audioSource = this.GetComponent<AudioSource>();
        audioSource.Play();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
