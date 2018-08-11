using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObjects : MonoBehaviour {

    public Transform player;
    public Transform playerCamera;
    public float throwforce = 100f;

    private bool hasPlayer = false;  // checks if player is within range
    private bool beingCarried = false;  // checks if being carried
    private bool touched = false;
    private float distance = 200f;

    //public AudioClip[] soundToPlay;
    //private AudioSource audioSource;


	// Use this for initialization
	void Start () {

        //audioSource = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player").transform;
        playerCamera = GameObject.FindWithTag("MainCamera").transform;
		
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // object is avaliable to be picked up
        if (dist < distance)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        // if the obj is close enough and clicked
        if (hasPlayer && Input.GetMouseButton(0))
        {
            // pick it up
            GetComponent<Rigidbody>().isKinematic = true; // don't have to deal with gravity >.<
            transform.parent = playerCamera;
            beingCarried = true;
        }

        // if being carried
        if (beingCarried)
        {
            // if it touches something, drop it
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            // if right clicked, throw it
            if (Input.GetMouseButton(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent<Rigidbody>().AddForce(playerCamera.forward * throwforce);
                //Play Audio here
            }
            // if released from holding, drop it
            else if ( Input.GetMouseButton(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }

		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
