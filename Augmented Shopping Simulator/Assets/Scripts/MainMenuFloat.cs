using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFloat : MonoBehaviour {

    private float yaw;
    private float pitch;
    private Rect screenRect = new Rect(0, 0, Screen.width, Screen.height);
    // Update is called once per frame
    void Update () {
        
        if (screenRect.Contains(Input.mousePosition))
        {
            yaw += -0.15f * Input.GetAxis("Mouse X");
            pitch -= -0.15f * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }

    }
}
