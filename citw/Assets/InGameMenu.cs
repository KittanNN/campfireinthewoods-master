using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {

    public Transform menu;
    public Transform deathMenu;

	// Use this for initialization
	void Start () {
        menu.gameObject.SetActive(false);
        deathMenu.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) && !MenuPause.isDead)
        {
            toggleMenu();
        }

	}

    public void toggleMenu()
    {
        menu.gameObject.SetActive(MenuPause.isMenuOpen = !menu.gameObject.activeSelf);

    }

    public void loadMainMenu()
    {
        MenuPause.isDead = MenuPause.isMenuOpen = false;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void openDeathMenu()
    {
        deathMenu.gameObject.SetActive(true);
    }

    public void Restart()
    {
        MenuPause.isDead = MenuPause.isMenuOpen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
