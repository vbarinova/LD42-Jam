using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    private GameObject maincamera;
    private bool carrying = false;
    private GameObject carriedObj;
    private float distance = 5f;
    private float smooth = 3f;
    private int clickDistance = 300;
    private float throwForce = 20f;

	// Use this for initialization
	void Start () {
        maincamera = GameObject.FindWithTag("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update () {
        if (carrying)
        {
            carry(carriedObj);

            // check for drop
            checkDrop();
        }
        else
        {
            PickUpObj();
        }
		
	}

    private void carry(GameObject carryObj)
    {
        // make obj hoover in front of center
        carryObj.transform.position = Vector3.Lerp(carryObj.transform.position,
                                        maincamera.transform.position + maincamera.transform.forward * distance,
                                        Time.deltaTime * smooth);
    }

    private void PickUpObj()
    {

        // trhow with right mouse button
        if (Input.GetKeyDown("left shift") && carrying == true)
        {
            carriedObj.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
            dropObject();
            Debug.Log("THrowing");
        }

        // if the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // determin middle of screen
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            // shoot a ray from the middle of the screen
            Ray ray = maincamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, clickDistance))
            {
                // check if the object can be picked up, if it has the
                // pickupable script
                Pickupable pickedUp = hit.collider.GetComponent<Pickupable>();
                if (pickedUp != null)
                {
                    carrying = true;
                    carriedObj = pickedUp.gameObject;

                    // set to kinematic so we do not have to worry about gravity
                    pickedUp.GetComponent<Rigidbody>().useGravity = false;
                    pickedUp.GetComponent<Rigidbody>().detectCollisions = true;

                    
                }
            }
        }

        

    }

    private void checkDrop()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dropObject();
        }
    }

    private void dropObject()
    {
        // reverse everything to pick it up
        carrying = false;

        // set to kinematic so we do not have to worry about gravity
        carriedObj.GetComponent<Rigidbody>().useGravity = true;

        // un save the obj
        carriedObj = null;
    }
}
