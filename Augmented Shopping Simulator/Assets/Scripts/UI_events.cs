using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_events : MonoBehaviour {

    public string menulevel;
    public string mainlevel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}




    public void loadMenu()
    {
        SceneManager.LoadScene(menulevel);
    }


    public void Restart()
    {
        SceneManager.LoadScene(mainlevel);
    }

    public void buttonQuit()
    {
        Application.Quit();
    }
}
