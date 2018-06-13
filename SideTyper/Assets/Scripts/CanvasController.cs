using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	[SerializeField]
	private GameObject winPanel;
	[SerializeField]
	private GameObject losePanel;
	[SerializeField]
	private GameObject againPanel;

	public void win(){
		winPanel.SetActive(true);
		againPanel.SetActive(true);
	}

	public void lose(){
		losePanel.SetActive(true);
		againPanel.SetActive(true);
	}

	public void init(){
		winPanel.SetActive(false);
		losePanel.SetActive(false);
		againPanel.SetActive(false);
	}
}
