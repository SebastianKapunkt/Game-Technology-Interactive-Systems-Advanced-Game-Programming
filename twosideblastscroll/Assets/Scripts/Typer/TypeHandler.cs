using UnityEngine;
using UnityEngine.UI;

public class TypeHandler : MonoBehaviour
{
    [SerializeField]
    private InputField theInput;
    [SerializeField]
    private TyperGod god;

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
                god.moveTyperLaneLeft();
                return;
            case "right":
                god.moveTyperLaneRight();
                return;
        }

        god.destroyObjectWithKeyWord(text);
    }
    
}