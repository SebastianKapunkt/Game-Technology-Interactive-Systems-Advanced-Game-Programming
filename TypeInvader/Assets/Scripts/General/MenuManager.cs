using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	[SerializeField]
	private GameObject stringInputPanel;
	[SerializeField]
	private InputField keyWordInput;

	public void openStringMenu(){
		stringInputPanel.SetActive(true);
	}

	public void closeStringMenu(){
		stringInputPanel.SetActive(false);
	}

	public void loadGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void quit(){
		Application.Quit();
	}

	public void saveKeyWords(){
		string[] keyWords = TextConverterUtil.convertToArray(keyWordInput.text);
		SaveLoad.Save(keyWords);
		loadKeyWords();
	}

	public void loadKeyWords(){
		string[] keyWords = SaveLoad.Load();
		keyWordInput.text = string.Join(" ", keyWords);
	}
}
