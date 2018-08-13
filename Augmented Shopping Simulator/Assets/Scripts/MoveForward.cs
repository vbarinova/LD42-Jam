using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject Destination;

    private float speed = 2f;
    private Vector3 move;

	// Use this for initialization
	void Start () {

        // start the player at the begining of the game
        // for now I am setting that as (0,7,0)
        Vector3 startingPos = new Vector3(0f, 7f, 0f);

        Player.transform.position = startingPos;


    }
	
	// Update is called once per frame
	void FixedUpdate () {
       
        // if the player has not reached the end, keep moving forward
        if (!Destination.GetComponent<ReachedEnd>().gameOver())
        {
            // move player forward in the z direction
            Player.transform.position += transform.forward * speed * Time.deltaTime;
            //Debug.Log("moving, chooo chooo");
        }
        // if the player has reached the end of the row, stop them
        else
        {
            // do nothing
            Debug.Log("This should never output");
        }


    }
}
