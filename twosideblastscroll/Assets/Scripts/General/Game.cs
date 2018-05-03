using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game { 
 
    public static Game current;
    public static string[] keyWords;
 
    public Game () {
        current = this;
        keyWords = new string[2]{"Hey", "Ho"};
    }
         
}