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
        string Path_Icon = PokemonData.Database[0].GeneralInformation.Icon;
        string Path_Icon_1 = PokemonData.Database[0].GeneralInformation.IconShiny;

        for (int i = 0; i < PokemonData.Count; i++)
        {
            if (Database.PokemonData[i].GeneralInformation.Reference == Ref)
                Database.PokemonData[i].GeneralInformation.Reference = Database.PokemonData[i].GeneralInformation.Name.ToLower(true);
            /*if (Database.PokemonData[i].ID == -1)
                Database.PokemonData[i].ID = i;*/
            if (Database.PokemonData[i].GeneralInformation.Icon == Path_Icon)
                Database.PokemonData[i].GeneralInformation.Icon = "Sheet1stGen/" + Database.PokemonData[i].GeneralInformation.Reference;
            if (Database.PokemonData[i].GeneralInformation.IconShiny == Path_Icon_1)
                Database.PokemonData[i].GeneralInformation.IconShiny = "Sheet1stGenShiny/" + Database.PokemonData[i].GeneralInformation.Reference;
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

    static public PokemonData LoadData(Monster Monster)
    {
        int Index = 0;

        for (int i = 0; i < PokemonData.Count; i++)
        {
            if (PokemonData.GetDatabase()[i].GeneralInformation.Monster == Monster)
                Index = i;
        }

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

    public P_Information GeneralInformation = new P_Information();

    public P_Pokedex_Entry Pokedex_Entry = new P_Pokedex_Entry();

    public P_BaseStats BaseStats = new P_BaseStats();

    public P_Evolution Evolution = new P_Evolution();

    public P_Moves[] MoveList;

    public P_Breeding Breeding = new P_Breeding();

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
                    TypePrimus = P_Type.Grass,
                    TypeSecundus = P_Type.Poison,
                    Ability_0 = P_Ability.Overgrow,
                    Ability_hidden = P_Ability.Chlorophyll
                },
                Pokedex_Entry = new P_Pokedex_Entry()
                {
                    Index = 1,
                    Description = "There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger."
                },
                BaseStats = new P_BaseStats()
                {
                    HP = 45,
                    Attack = 49,
                    Defense = 49,
                    SpecialAttack = 65,
                    SpecialDefense = 65,
                    Speed = 45
                },
                Evolution = new P_Evolution()
                {
                    EvolutionType = P_EvolutionType.Lvl,
                    EvolutionPokemon = Monster.ivysaur,    //TODO add Pokemon
                    Level = 16,
                    Item = null
                },
                MoveList = new P_Moves[]
                {
                    new P_Moves()
                    {
                        Move = Move.Tackle,
                        LvlUP = 1
                    },
                    new P_Moves()
                    {
                        Move = Move.Growl,
                        LvlUP = 1
                    },
                    new P_Moves()
                    {
                        Move = Move.VineWhip,
                        LvlUP = 3
                    },
                    new P_Moves()
                    {
                        Move = Move.Growth,
                        LvlUP = 6
                    },
                    new P_Moves()
                    {
                        Move = Move.LeechSeed,
                        LvlUP = 9
                    },
                    new P_Moves()
                    {
                        Move = Move.RazorLeaf,
                        LvlUP = 12
                    },
                    new P_Moves()
                    {
                        Move = Move.PoisonPowder,
                        LvlUP = 15
                    },
                    new P_Moves()
                    {
                        Move = Move.SleepPowder,
                        LvlUP = 15
                    },
                    new P_Moves()
                    {
                        Move = Move.SeedBomb,
                        LvlUP = 18
                    },
                    new P_Moves()
                    {
                        Move = Move.TakeDown,
                        LvlUP = 21
                    }
                },
                Breeding = new P_Breeding()
                {
                    hasGender = true,
                    MaleRatio = 0.875f,
                    CatchRate = 45,
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
            },  //Bulbasaur
            new PokemonData()
            {
                GeneralInformation = new P_Information()
                {
                    Monster = Monster.ivysaur,
                    Name = "Ivysaur",
                    TypePrimus = P_Type.Grass,
                    TypeSecundus = P_Type.Poison,
                    Ability_0 = P_Ability.Overgrow,
                    Ability_hidden = P_Ability.Chlorophyll
                },
                Pokedex_Entry = new P_Pokedex_Entry()
                {
                    Index = 2,
                    Description = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs."
                },
                BaseStats = new P_BaseStats()
                {
                    HP = 60,
                    Attack = 62,
                    Defense = 63,
                    SpecialAttack = 80,
                    SpecialDefense = 80,
                    Speed = 60
                },
                Evolution = new P_Evolution()
                {
                    EvolutionType = P_EvolutionType.Lvl,
                    EvolutionPokemon = Monster.none,    //TODO add Pokemon
                    Level = 32,
                    Item = null
                },
                MoveList = new P_Moves[]
                {
                    new P_Moves()
                    {
                        Move = Move.Tackle,
                        LvlUP = 1
                    },
                    new P_Moves()
                    {
                        Move = Move.Growl,
                        LvlUP = 1
                    },
                    new P_Moves()
                    {
                        Move = Move.VineWhip,
                        LvlUP = 1
                    },
                    new P_Moves()
                    {
                        Move = Move.Growth,
                        LvlUP = 1
                    },
                    new P_Moves()
                    {
                        Move = Move.LeechSeed,
                        LvlUP = 9
                    },
                    new P_Moves()
                    {
                        Move = Move.RazorLeaf,
                        LvlUP = 12
                    },
                    new P_Moves()
                    {
                        Move = Move.PoisonPowder,
                        LvlUP = 15
                    },
                    new P_Moves()
                    {
                        Move = Move.SleepPowder,
                        LvlUP = 15
                    },
                    new P_Moves()
                    {
                        Move = Move.SeedBomb,
                        LvlUP = 20
                    },
                    new P_Moves()
                    {
                        Move = Move.TakeDown,
                        LvlUP = 25
                    }
                },
                Breeding = new P_Breeding()
                {
                    hasGender = true,
                    MaleRatio = 0.875f,
                    CatchRate = 45,
                    YieldExp = 142,
                    YieldEV = new P_Breeding.P_EVYield()
                    {
                        SAt = 1,
                        SDe = 1
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
            }   //Ivysaur
        };
    }

    #endregion

    #region Methods

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

    #endregion
}

#region SubClasses

[System.Serializable]
public class P_Information
{
    public Monster Monster = Monster.none;
    public string Name = "Placeholder Name";
    public string Reference = "Placeholder Reference";
    public string Icon = ""; //add path -> string
    /*
     * https://stackoverflow.com/questions/41313398/get-single-sprite-from-sprite-atlas
     */
    public string IconShiny = "";
    public P_Type TypePrimus = P_Type.none;
    public P_Type TypeSecundus = P_Type.none;
    public P_Ability Ability_0 = P_Ability.none;
    public P_Ability Ability_1 = P_Ability.none;
    public P_Ability Ability_hidden = P_Ability.none;
}

[System.Serializable]
public class P_Pokedex_Entry
{
    public int Index = -1;
    public string Description = "Placeholder Description";
}

/// <summary>
/// These Stats are base Stats and get multiplied with Level, etc.
/// </summary>

[System.Serializable]
public class P_BaseStats
{
    public int HP;

    public int Attack;
    public int Defense;

    public int SpecialAttack;
    public int SpecialDefense;

    public int Speed;
}

[System.Serializable]
public class P_Evolution
{
    public P_EvolutionType EvolutionType = P_EvolutionType.none;
    public Monster EvolutionPokemon = Monster.none;
    public int Level;
    public Item Item;
}

[System.Serializable]
public class P_Moves
{
    public Move Move = Move.none;
    public P_MoveTree MoveTree = P_MoveTree.LevelUp;
    public int LvlUP;
}

[System.Serializable]
public class P_Breeding
{
    public bool hasGender = true;
    public float MaleRatio;

    public int CatchRate;
    public int YieldExp;
    public P_EVYield YieldEV;
    public P_LvLRate LvlRate = P_LvLRate.Erratic;
    public int BaseHappiness = 70;

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

public enum Monster
{
    none,
    bulbasaur,
    ivysaur
}

public enum P_Ability
{
    none,
    Overgrow,
    Chlorophyll
}

#endregion