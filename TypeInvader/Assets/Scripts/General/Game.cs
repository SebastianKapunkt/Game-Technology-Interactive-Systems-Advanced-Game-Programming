using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Game { 
 
    public static Game current;
    public static string[] keyWords;
 
    public Game () {
        current = this;
        string defaultText = "Cats Cats sleep Anywhere, Any table, Any chair, Top of piano, Window-ledge, In the middle, On the edge, Open drawer, Empty shoe, Anybody's Lap will do, Fitted in a Cardboard box, In the cupboard With your frocks – Anywhere! They don't care! Cats sleep Anywhere.";
        keyWords = TextConverterUtil.convertToArray(defaultText);
    }
         
}