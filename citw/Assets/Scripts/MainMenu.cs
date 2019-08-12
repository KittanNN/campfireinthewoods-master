using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    bool canStart;
    bool showTut;

    public GameObject[] tutorials;

    int tut;

	// Use this for initialization
	void Start () {
        foreach (var tutorial in tutorials)
        {
            tutorial.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.Space)) {
            print("asd");
        }


        if (Input.GetKeyDown(KeyCode.Space) && canStart)
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && showTut && !canStart)
        {
            nextTutorial();
        }
	}

    public void nextTutorial()
    {
        tutorials[tut].SetActive(true);
        
        showTut = true;
        ++tut;
        canStart = tut == tutorials.Length ? true : false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
