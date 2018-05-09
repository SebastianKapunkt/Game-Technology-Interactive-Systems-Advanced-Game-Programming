using System;
using System.Collections.Generic;

public class TextConverterUtil
{
    private static List<string> charactersToRemove = new List<string>(){
        "#",
        "!",
        "(",
        ")",
        ";",
        ":",
        "?",
        "-",
        "–",
        "_",
        ",",
        "'",
        ".",
        "<",
        ">",
        "@",
        "=",
        "\""
    };

    internal static string[] convertToArray(string text)
    {
        text = removeSepcialCharacters(text);
        string[] allKeyWords = splitToArray(text);
        return distinctKeyWords(allKeyWords);
    }

    private static string[] distinctKeyWords(string[] allKeyWords)
    {
        HashSet<string> distinct = new HashSet<string>();
        for (int i = 0; i < allKeyWords.Length; i++)
        {
            distinct.Add(allKeyWords[i]);
        }
        String[] distinctArray = new String[distinct.Count];
        distinct.CopyTo(distinctArray);
        return distinctArray;
    }

    private static string[] splitToArray(string text)
    {
        text = text.Replace(" ", ",");
        while (text.Contains(",,"))
        {
            text = text.Replace(",,", ",");
        }
        if (text.Length > 1)
        {
            return text.Split(',');
        }
        return new string[1] { " " };
    }

    private static string removeSepcialCharacters(string text)
    {
        foreach (string toRemove in charactersToRemove)
        {
            text = text.Replace(toRemove, "");
        }
        return text;
    }
}