using UnityEngine;
using System.IO;

[System.Serializable]
public class SavePlayerData
{
    public string Name;
    public string Place;
    public float Playtime;
    public int PokedexCount;
}

public static class LoadPlayerData
{
    public static SavePlayerData Read(string Path)
    {
        string jsonString = File.ReadAllText(Application.dataPath + "/SaveFiles/" + Path +".json");

        return JsonUtility.FromJson<SavePlayerData>(jsonString);
    }
}


public static class SaveFunctions
{
    public static void Save()
    {
        SavePlayerData PlayerData = new SavePlayerData();

        //change to global Variable
        PlayerData.Name = "Henri";
        PlayerData.Place = "Fahrschule";
        PlayerData.Playtime = 47853892f;
        PlayerData.PokedexCount = 42;

        WriteToJSON("PlayerData", JsonUtility.ToJson(PlayerData, true));
    }

    public static void WriteToJSON(string Path, string JSONString)
    {
        File.WriteAllText(Application.dataPath + "/SaveFiles/" + Path + ".json", JSONString);

        Debug.Log(JSONString);
    }

    public static void Update()
    {
        SavePlayerData PlayerData = new SavePlayerData();

        //change to global Variable
        PlayerData.Name = "Henri";
        PlayerData.Place = "Living Room";
        PlayerData.Playtime = 900f;
        PlayerData.PokedexCount = 42;

        OverwriteJSON(JsonUtility.ToJson(PlayerData, true), PlayerData);
    }

    public static void OverwriteJSON(string JSONString, object JSON)
    {
        JsonUtility.FromJsonOverwrite(JSONString, JSON);

        Debug.Log(JSONString);
    }
}