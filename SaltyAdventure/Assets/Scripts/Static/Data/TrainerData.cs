using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrainerData
{
    #region Variables

    public string Name;
    public string ID;
    public string HiddenID;
    public Gender Gender = Gender.None;

    public int Money = 0;
    //public int Coins = 0;

    public int Badges = 0;
    public int Pokedex = 0;
    public int Score = 0;

    public float Playtime = 0f;
    public float StartDate;

    public static TrainerData[] Database;

    #endregion

    #region Database

    static TrainerData() => Database = new TrainerData[]
    {
        new TrainerData()
        {
            Name = "Henri",
            ID = "123456",
            Money = 5500
        }   //Debug Trainer
    };

    #endregion

    #region Methods

    public static TrainerData GetData()
    {
        return Database[0];
    }

    #endregion
}
