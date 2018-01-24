using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject optionsPanel;

    public GameObject idleBackground;
    public GameObject activeBackground;

	void Start () {
        Idle();
        OpenMenu();
	}

    public void Idle() {
        idleBackground.SetActive(true);
        activeBackground.SetActive(false);
    }

    public void Hover() {
        idleBackground.SetActive(false);
        activeBackground.SetActive(true);
    }

    public void LoadLevel(string levelName) {
        SceneManager.LoadScene (levelName);
    }

    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void OpenCredits() {
        mainPanel.SetActive (false);
        creditsPanel.SetActive (true);
        optionsPanel.SetActive (false);
    }

    public void OpenOptions() {
        mainPanel.SetActive (false);
        creditsPanel.SetActive (false);
        optionsPanel.SetActive (true);
    }

    public void OpenMenu() {
        mainPanel.SetActive (true);
        creditsPanel.SetActive (false);
        optionsPanel.SetActive (false);
    }
}
