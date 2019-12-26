using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon
{
    public string Name;

    public Monster Monster = Monster.none;
    public P_Nature Nature = P_Nature.none;
    public P_Ability Ability = P_Ability.none;
    public Item_Item HeldItem = Item_Item.none;

    public P_Trainer TrainerInfo;
    public P_Stats Stats;
    public Live_Stats LiveStats = new Live_Stats();
    public DeterminantValues DValues;
    public EffortValues EValues;

    public Gender Gender = Gender.None;
    public bool isShiny = false;
    public int Level = 1;
    public int Experience;
    public int Happiness;

    public BaseMove[] Moves = new BaseMove[4];

    public void AddMember(BasePokemon bp)
    {
        Name = bp.Name;
        Monster = bp.Monster;
        HeldItem = bp.HeldItem;
        TrainerInfo = bp.TrainerInfo;
        LiveStats = bp.LiveStats;
        isShiny = bp.isShiny;
        Level = bp.Level;
        Stats = bp.Stats;

        /**/
        PokemonData Data = PokemonData.GetData(Monster);

        LiveStats.HP = Data.BaseStats.HP;
        LiveStats.Attack = Data.BaseStats.Attack;
        LiveStats.Defense = Data.BaseStats.Defense;
        LiveStats.SpecialAttack = Data.BaseStats.SpecialAttack;
        LiveStats.SpecialDefense = Data.BaseStats.SpecialDefense;
        LiveStats.Speed = Data.BaseStats.Speed;

        /*
        LiveStats.HP = bp.Kind.BaseStats.HPStat;
        LiveStats.Attack = bp.Kind.BaseStats.AttackStat;
        LiveStats.Defence = bp.Kind.BaseStats.DefenceStat;
        LiveStats.SpecialAttack = bp.Kind.BaseStats.SpAttackStat;
        LiveStats.SpecialDefence = bp.Kind.BaseStats.SpDefenceStat;
        LiveStats.Speed = bp.Kind.BaseStats.SpeedStat;
        */
    }   //TODO can this be removed?
}

#region SubClasses

[System.Serializable]
public class P_Trainer
{
    public string TrainerName;
    public string TrainerID;

    public Place Place = Place.none;
    public string Time;
}

[System.Serializable]
public class P_Stats
{
    public int HP;
    public int Attack;
    public int Defense;
    public int SpecialAttack;
    public int SpecialDefense;
    public int Speed;
}

[System.Serializable]
public class Live_Stats
{
    public int HP = 0;
    //reset after battle
    public int Attack = 0;
    public int Defense = 0;
    public int SpecialAttack = 0;
    public int SpecialDefense = 0;
    public int Speed = 0;
}

/// <summary>
/// Every Stat is a value between 0 - 31
/// </summary>
[System.Serializable]
public class DeterminantValues
{
    public int HP;
    public int Attack;
    public int Defense;
    public int SpecialAttack;
    public int SpecialDefense;
    public int Speed;
}

/// <summary>
/// Every Stat is a value between 0 - 252.
/// Total Maximum is 510
/// </summary>
[System.Serializable]
public class EffortValues
{
    public int HP = 0;
    public int Attack = 0;
    public int Defense = 0;
    public int SpecialAttack = 0;
    public int SpecialDefense = 0;
    public int Speed = 0;
}

#endregion

#region Enums

public enum P_Nature
{
    none,
    Hardy,
	Lonely,
	Brave,
	Adamant,
	Naughty,
	Bold,
	Docile,
	Relaxed,
	Impish,
	Lax,
	Timid,
	Hasty,
	Serious,
	Jolly,
	Naive,
	Modest,
	Mild,
	Quiet,
	Bashful,
	Rash,
	Calm,
	Gentle,
	Sassy,
	Careful,
	Quirky
}

#endregion