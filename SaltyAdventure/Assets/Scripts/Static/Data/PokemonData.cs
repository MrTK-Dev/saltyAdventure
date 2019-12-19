using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides Functions to write and read from JSON for Handling of the PokemonData Class.
/// </summary>
public static class JSON_PokemonData
{
    /// <summary>
    /// Writes all PokemonData(s) to a JSON.
    /// </summary>
    static public void WriteDataBase()
    {
        PokemonDataBase Database = new PokemonDataBase
        {
            PokemonData = PokemonData.GetDatabase()
        };

        //cache
        string Ref = PokemonData.Database[0].GeneralInformation.Reference;

        for (int i = 0; i < PokemonData.Count; i++)
        {
            if (Database.PokemonData[i].GeneralInformation.Reference == Ref)
                Database.PokemonData[i].GeneralInformation.Reference = Database.PokemonData[i].GeneralInformation.Name.ToLower(true);
            /*if (Database.PokemonData[i].ID == -1)
                Database.PokemonData[i].ID = i;*/
        }

        DataManagment.WriteToJSON(Database, "PokemonData/Monster");
    }

    /// <summary>
    /// Return the whole DataBase (Class).
    /// Use with DataBase.PokemonData[Index].
    /// </summary>
    /// <returns></returns>
    static public PokemonDataBase LoadDataBase()
    {
        string JSON = DataManagment.ReadFromJSON("PokemonData/Monster");

        return JsonUtility.FromJson<PokemonDataBase>(JSON);
    }

    /// <summary>
    /// Returns PokemonData with a given Index.
    /// </summary>
    /// <param name="Index"></param>
    /// <returns>PokemonData</returns>
    static public PokemonData LoadData(int Index)
    {
        return LoadDataBase().PokemonData[Index];
    }
}

/// <summary>
/// This Class functions purely as a JSON-Helper.
/// </summary>
public class PokemonDataBase
{
    public PokemonData[] PokemonData;
}

/// <summary>
/// An Array of registered Pokemon Kinds.
/// Only override variable different to default.
/// </summary>
[System.Serializable]
public class PokemonData
{
    #region Variables

    public P_Information GeneralInformation = new P_Information()
    {
        Monster = Monster.none,
        Name = "Placeholder Name",
        //Reference = "placeholder_name", //TODO override inside class (like MoveData)
        Icon = null,
        IconShiny = null,
        TypePrimus = P_Type.none,
        TypeSecundus = P_Type.none
    };

    public P_Pokedex_Entry Pokedex_Entry = new P_Pokedex_Entry()
    {
        Index = -1,
        Description = "Placeholder Description"
    };

    public P_BaseStats BaseStats = new P_BaseStats()
    {
        HPStat = 0,
        AttackStat = 0,
        DefenceStat = 0,
        SpAttackStat = 0,
        SpDefenceStat = 0,
        SpeedStat = 0
    };

    public P_Evolution Evolution = new P_Evolution()
    {
        EvolutionType = P_EvolutionType.none,
        EvolutionPokemon = Monster.none,
        Level = -1,
        Item = null
    };

    public P_Moves[] MoveList = new P_Moves[]
    {
        new P_Moves()
        {
            Move = Move.none,
            MoveTree = P_MoveTree.LevelUp,
            LvlUP = -1
        }
    };

    public P_Breeding Breeding = new P_Breeding()
    {
        hasGender = true,
        MaleRatio = -1,
        CatchRate = 0,
        YieldExp = 0,
        YieldEV = new P_Breeding.P_EVYield()
        {
            HP = 0,
            Att = 0,
            Def = 0,
            SAt = 0,
            SDe = 0,
            Sp = 0
        },
        LvlRate = P_LvLRate.Medium,
        BaseHappiness = 0,
        HatchTime = new int[] { 0, 0 },
        EggGroups = new P_EggGroup[]
        {
            P_EggGroup.none
        }
    };

    #endregion

    public static int Count { get { return Database.Length; } }
    public static PokemonData[] Database;

    #region DataBase

    static PokemonData()
    {
        Database = new PokemonData[]
        {
            new PokemonData()
            {
                Pokedex_Entry = new P_Pokedex_Entry()
                {
                    Index = 0
                }
            },

            new PokemonData()
            {
                GeneralInformation = new P_Information()
                {
                    Monster = Monster.bulbasaur,
                    Name = "Bulbasaur",
                    Icon = null,
                    IconShiny = null,
                    TypePrimus = P_Type.Grass,
                    TypeSecundus = P_Type.Poison
                },
                Pokedex_Entry = new P_Pokedex_Entry()
                {
                    Index = 1,
                    Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger."
                },
                BaseStats = new P_BaseStats()
                {
                    HPStat = 45,
                    AttackStat = 49,
                    DefenceStat = 49,
                    SpAttackStat = 65,
                    SpDefenceStat = 65,
                    SpeedStat = 45
                },
                Evolution = new P_Evolution()
                {
                    EvolutionType = P_EvolutionType.Lvl,
                    EvolutionPokemon = Monster.none,    //TODO add Pokemon
                    Level = 16,
                    Item = null
                },
                MoveList = new P_Moves[]
                {
                    new P_Moves()
                    {
                        Move = Move.tackle,
                        LvlUP = 1
                    }
                },
                Breeding = new P_Breeding()
                {
                    hasGender = true,
                    MaleRatio = 0.875f,
                    CatchRate = 0.119f,
                    YieldExp = 64,
                    YieldEV = new P_Breeding.P_EVYield()
                    {
                        SAt = 1
                    },
                    LvlRate = P_LvLRate.MediumSlow,
                    BaseHappiness = 70,
                    HatchTime = new int[] { 5140, 5396 },
                    EggGroups = new P_EggGroup[]
                    {
                        P_EggGroup.Monster,
                        P_EggGroup.Grass
                    }
                }
            }
        };
    }

    #endregion

    public static PokemonData GetData(int Index)
    {
        return Database[Index];
    }

    public static PokemonData GetData(Monster Monster)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Database[i].GeneralInformation.Monster == Monster)
            {
                return Database[i];
            }
        }

        return Database[0];
    }

    public static PokemonData[] GetDatabase()
    {
        return Database;
    }
}

#region SubClasses

[System.Serializable]
public class P_Information
{
    public Monster Monster;
    public string Name;
    public string Reference;
    public Sprite Icon; //TODO add path -> string
    /*
     * https://stackoverflow.com/questions/41313398/get-single-sprite-from-sprite-atlas
     */
    public Sprite IconShiny;
    public P_Type TypePrimus;
    public P_Type TypeSecundus;
}

[System.Serializable]
public class P_Pokedex_Entry
{
    public int Index;
    public string Description;
}

/// <summary>
/// These Stats are base Stats and get multiplied with Level, etc.
/// </summary>

[System.Serializable]
public class P_BaseStats
{
    public int HPStat;

    public int AttackStat;
    public int DefenceStat;

    public int SpAttackStat;
    public int SpDefenceStat;

    public int SpeedStat;
}

[System.Serializable]
public class P_Evolution
{
    public P_EvolutionType EvolutionType;
    public Monster EvolutionPokemon;
    public int Level;
    public Item Item;
}

[System.Serializable]
public class P_Moves
{
    public Move Move;
    public P_MoveTree MoveTree;
    public int LvlUP;
}

[System.Serializable]
public class P_Breeding
{
    public bool hasGender;
    public float MaleRatio;

    public float CatchRate;
    public int YieldExp;
    public P_EVYield YieldEV;
    public P_LvLRate LvlRate;
    public int BaseHappiness;

    public int[] HatchTime = new int[2];
    public P_EggGroup[] EggGroups;

    #region SubClass

    [System.Serializable]
    public class P_EVYield
    {
        public int HP;
        public int Att;
        public int Def;
        public int SAt;
        public int SDe;
        public int Sp;
    }

    #endregion
}

#endregion

#region Enums

/// <summary>
/// Type of the Pokemon.
/// The Types have to be different for one Kind of Pokemon!
/// </summary>
[System.Serializable]
public enum P_Type
{
    Bug,
    Dark,
    Dragon,
    Electric,
    Fairy,
    Fighting,
    Fire,
    Flying,
    Ghost,
    Grass,
    Ground,
    Ice,
    Normal,
    Poison,
    Psychic,
    Rock,
    Steel,
    Water,

    none
}

[System.Serializable]
public enum P_EvolutionType
{
    none,
    Lvl,
    Trade
}

[System.Serializable]
public enum P_MoveTree
{
    LevelUp,
    Trade,
    TM,
    Egg
}

[System.Serializable]
public enum P_EggGroup
{
    none,
    Monster,
    Grass
}

[System.Serializable]
public enum P_LvLRate
{
    Slow,
    MediumSlow,
    Medium,
    MediumFast,
    Fast,
    Fluctuating
}

public enum Monster
{
    none,
    bulbasaur
}

#endregion