using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelControl : MonoBehaviour {

	[SerializeField]
	GameObject helpPanel;
	[SerializeField]
	GameObject gameOverPanel;

	// Use this for initialization
	void Start () {
		helpPanel.SetActive(true);
		gameOverPanel.SetActive(false);
	}
	
	public void showHelp(){
		helpPanel.SetActive(true);
		gameOverPanel.SetActive(false);
	}

	public void hideHelp(){
		helpPanel.SetActive(false);
	}

    internal bool helpIsActive()
    {
        return helpPanel.activeInHierarchy;
    }

    internal void showGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    internal void hideGameOver()
    {
        gameOverPanel.SetActive(false);
    }
}
