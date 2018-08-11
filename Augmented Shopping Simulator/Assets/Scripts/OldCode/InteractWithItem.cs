using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithItem : MonoBehaviour {
    private float throwforce = 600f;
    private Vector3 objectPos;
    private float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;

    // Update is called once per frame
    void Update()
    {
        // Check if isHolding
        if (isHolding == true)
        {
            //to help with collisions
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            //set parent
            item.transform.SetParent(tempParent.transform);

            // trhow with right mouse button
            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwforce);
                isHolding = false;
            }
        }
        // if not holding
        else
        {
            // save position
            objectPos = item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        isHolding = true;
        item.GetComponent<Rigidbody>().useGravity = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        Debug.Log("Clicked: " + this.gameObject);
    }

    void OnMouseUp()
    {
        isHolding = false;
    }
}
