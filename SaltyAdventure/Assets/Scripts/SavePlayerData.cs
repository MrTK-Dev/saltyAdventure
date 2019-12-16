using UnityEngine;
using System.IO;

/// <summary>
/// Provides Functions to write and read from JSON for Handling of the PlayerData Class.
/// </summary>
public static class JSON_PlayerData
{
    /// <summary>
    /// Writes all PlayerData(s) to a JSON.
    /// </summary>
    static public void WriteDataBase()
    {
        PlayerDataBase Database = new PlayerDataBase
        {
            PlayerData = PlayerData.GetDatabase()
        };

        //cache
        //string Ref = PlayerData.Database[0].Reference;

        /*for (int i = 0; i < PlayerData.Count; i++)
        {
            if (Database.PlayerData[i].ID == -1)
                Database.PlayerData[i].ID = i;
        }*/

        DataManagment.WriteToJSON(Database, "PokemonData/Data");
    }

    /// <summary>
    /// Return the whole DataBase (Class).
    /// Use with DataBase.PlayerData[Index].
    /// </summary>
    /// <returns></returns>
    static public PlayerDataBase LoadDataBase()
    {
        string JSON = DataManagment.ReadFromJSON("PokemonData/Data");

        return JsonUtility.FromJson<PlayerDataBase>(JSON);
    }

    /// <summary>
    /// Returns PlayerData with a given Index.
    /// </summary>
    /// <param name="Index"></param>
    /// <returns>PlayerData</returns>
    static public PlayerData LoadData(int Index)
    {
        return LoadDataBase().PlayerData[Index];
    }
}

/// <summary>
/// This Class functions purely as a JSON-Helper.
/// </summary>
public class PlayerDataBase
{
    public PlayerData[] PlayerData;
}

[System.Serializable]
public class PlayerData
{
    #region Variables

    public int ID = -1;
    public int Trainer_ID = 00000;

    public string Name = "Placeholder Name";
    public Gender Gender = Gender.None;

    public string Place = "Placeholder Place"; //change to enum

    #endregion

    public static int Count { get { return Database.Length; } }
    public static PlayerData[] Database;

    static PlayerData()
    {
        Database = new PlayerData[]
        {
            new PlayerData()  //PlaceHolder
            {
                ID = 0
            }
        };
    }
    public static PlayerData GetData(int Index)
    {
        return Database[Index];
    }

    public static PlayerData[] GetDatabase()
    {
        return Database;
    }
}

public enum Gender
{
    None,
    Male,
    Female
}