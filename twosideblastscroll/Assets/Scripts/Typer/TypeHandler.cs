using UnityEngine;
using UnityEngine.UI;

public class TypeHandler : MonoBehaviour
{
    [SerializeField]
    private MoveController moveController;
    [SerializeField]
    private InputField theInput;

    void Update(){
        if(Input.GetKey(KeyCode.Return)) {
            handleInput(theInput.text);
            theInput.text = "";
            theInput.ActivateInputField();
        }
    }

    public void handleInput(string text){
        if(text == "") return;

        switch(text){
            case "left":
                moveController.MoveToX(2);
            break;
            case "right":
                moveController.MoveToX(-2);
            break;
        }
    }
    
}