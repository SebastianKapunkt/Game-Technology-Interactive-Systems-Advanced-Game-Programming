using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public static class SaveLoad
{
    public static Game game = new Game();

    //it's static so we can call it from anywhere
    public static void Save(string[] keyWords)
    {
        BinaryFormatter bf = new BinaryFormatter();
        Game.keyWords = keyWords;
        FileStream file = File.Create(Application.dataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, game);
        file.Close();
    }

    public static string[] Load()
    {
        if (File.Exists(Application.dataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/savedGames.gd", FileMode.Open);
            game = (Game)bf.Deserialize(file);
            file.Close();
            return Game.keyWords;
        }
        else
        {
            Save(Game.keyWords);
            return Game.keyWords;
        }
    }
}