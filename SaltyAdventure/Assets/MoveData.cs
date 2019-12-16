using UnityEngine;

/// <summary>
/// This Class provides Functions to write and read from JSON.
/// </summary>
public static class HandleMoveData
{
    /// <summary>
    /// Returns MoveData with the given Index.
    /// See also JSON_MoveData.LoadData().
    /// </summary>
    /// <param name="Index"></param>
    /// <returns>MoveData</returns>
    public static MoveData LoadData(int Index)
    {
        if (Index == 0)
            Debug.Log("You are probably requesting the wrong Move.\nIndex = 0 is only a Placeholder");

        return MoveData.Database[Index];
    }
}

/// <summary>
/// Provides Functions to write and read from JSON for Handling of the MoveData Class.
/// </summary>
public static class JSON_MoveData
{
    /// <summary>
    /// Writes all MoveData(s) to a JSON.
    /// </summary>
    static public void WriteDataBase()
    {
        MoveDataBase Database = new MoveDataBase
        {
            MoveData = MoveData.GetDatabase()
        };

        //cache
        string Ref = MoveData.Database[0].Reference;

        for (int i = 0; i < MoveData.Count; i++)
        {
            if (Database.MoveData[i].Reference == Ref)
                Database.MoveData[i].Reference = Database.MoveData[i].Name.ToLower(true);
            if (Database.MoveData[i].ID == -1)
                Database.MoveData[i].ID = i;
        }

        DataManagment.WriteToJSON(Database, "PokemonData/Data");
    }

    /// <summary>
    /// Return the whole DataBase (Class).
    /// Use with DataBase.MoveData[Index].
    /// </summary>
    /// <returns></returns>
    static public MoveDataBase LoadDataBase()
    {
        string JSON = DataManagment.ReadFromJSON("PokemonData/Data");

        return JsonUtility.FromJson<MoveDataBase>(JSON);
    }

    /// <summary>
    /// Returns MoveData with a given Index.
    /// </summary>
    /// <param name="Index"></param>
    /// <returns>MoveData</returns>
    static public MoveData LoadData(int Index)
    {
        return LoadDataBase().MoveData[Index];
    }
}

/// <summary>
/// This Class functions purely as a JSON-Helper.
/// </summary>
public class MoveDataBase
{
    public MoveData[] MoveData;
}

/// <summary>
/// An Array of registered Moves.
/// Only override variable different to default.
/// </summary>
[System.Serializable]
public class MoveData
{
    #region Variables

    public string Name = "Placeholder Name";
    public string Description = "Placeholder Description";

    /// <summary>
    /// This string is for reference through a string.
    /// Don't override for standard formatting:
    /// "placeholder_name"
    /// </summary>
    public string Reference = "placeholder_reference";
    public Move Move = Move.none;

    /// <summary>
    /// If ID stays at -1, check will throw error!
    /// </summary>
    public int ID = -1;
    public int Dmg = 0;
    public int Accuracy = 100;

    /// <summary>
    /// Index of the effect(s).
    /// </summary>
    public int[] Index;

    /// <summary>
    /// Prioritylist:
    /// [-2] Always last
    /// [-1] last
    /// [0] neutral
    /// [1] first
    /// [2] more first
    /// [3] Always first
    /// </summary>
    public int Priority = 0;
    public int PP = 0;

    public P_Type type = P_Type.none;
    public AttackType attackType = AttackType.None;

    #endregion

    public MoveData()
    {
        Reference = Name.ToLower(true);
    }

    public static int Count { get { return Database.Length; } }
    public static MoveData[] Database;

    #region DataBase

    static MoveData()
    {
        Database = new MoveData[]
        {
            new MoveData()
            {
                ID = 0
            },

            new MoveData()
            {
                Name = "Tackle",
                Description = "Attacks the Enemy",
                Move = Move.tackle,
                Dmg = 40,
                PP = 35,
                type = P_Type.Normal,
                attackType = AttackType.Physical
            },
            new MoveData()
            {
                Name = "Cut",
                Description = "Attacks the Enemy with a Cut",
                Move = Move.cut,
                Dmg = 35,
                Accuracy = 95,
                PP = 40,
                type = P_Type.Normal,
                attackType = AttackType.Physical
            },
            new MoveData()
            {
                Name = "Flamethrower",
                Description = "FIRE",
                Move = Move.flamethrower,
                Dmg = 75,
                PP = 10,
                type = P_Type.Fire,
                attackType = AttackType.Special
            }
        };
    }

    #endregion

    public static MoveData GetData(int Index)
    {
        return Database[Index];
    }

    public static MoveData GetData(Move Move)
    {
        for (int i = 0; i < MoveData.Count; i++)
        {
            if (Database[i].Move == Move)
            {
                return Database[i];
            }
        }

        return Database[0];
    }

    public static MoveData[] GetDatabase()
    {
        return Database;
    }
}

public enum AttackType
{
    None,

    Physical,
    Special,
    Status
}

public enum Move
{
    none,
    tackle,
    cut,
    flamethrower
}