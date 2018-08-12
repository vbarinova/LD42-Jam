using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvents : MonoBehaviour {

    public Canvas fade;
    public string levelname;
    public string fade_trigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void BeginGame()
    {
        Invoke("FadeTrigger", 2);
        Invoke("loadLevel", 3);
    }


    void loadLevel()
    {
        SceneManager.LoadScene(levelname);
    }

    void FadeTrigger()
    {
        fade.GetComponent<Animator>().Play(fade_trigger);
    }

    public void buttonQuit()
    {
        Application.Quit();
    }
}
