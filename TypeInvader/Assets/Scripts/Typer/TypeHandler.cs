using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TypeHandler : MonoBehaviour
{
    [SerializeField]
    private InputField theInput;
    [SerializeField]
    private TyperGod god;
    [SerializeField]
    private PanelControl panelControl;

    void Start(){
        theInput.ActivateInputField();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            handleInput(theInput.text);
            theInput.text = "";
            theInput.ActivateInputField();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && god.getState() == GameStates.Playing)
        {
            god.moveTyperLaneLeft();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && god.getState() == GameStates.Playing)
        {
            god.moveTyperLaneRight();
        }
    }

    public void handleInput(string text)
    {
        if (text == "") return;

        if (text == "help")
        {
            if (panelControl.helpIsActive())
            {
                panelControl.hideHelp();
            }
            else
            {
                panelControl.showHelp();
            }
        }

        if (text == "QUIT")
        {
            Application.Quit();
        }

        if (text == "goToMenu"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        if (god.getState() == GameStates.Stop || god.getState() == GameStates.Pause)
        {
            switch (text)
            {
                case "start":
                    panelControl.hideHelp();
                    god.startGame();
                    panelControl.hideGameOver();
                    return;
            }
        }
        if (god.getState() == GameStates.Pause)
        {
            switch (text)
            {
                case "continueit":
                    panelControl.hideHelp();
                    god.continueGame();
                    return;
            }
        }
        if (god.getState() == GameStates.Playing)
        {
            switch (text)
            {
                case "needbreak":
                    god.pauseGame();
                    panelControl.showHelp();
                    return;
            }
            god.destroyObjectWithKeyWord(text);
        }
    }
}