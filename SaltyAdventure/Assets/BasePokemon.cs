using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon : MonoBehaviour
{
    public string Name;
    public P_Kind Kind;
    public Item HeldItem;
    public P_Trainer TrainerInfo;
    public P_Stats Stats;
    public Live_Stats LiveStats;
    public bool isShiny;
    public int Level = 1;

    public void AddMember(BasePokemon bp)
    {
        Name = bp.Name;
        Kind = bp.Kind;
        HeldItem = bp.HeldItem;
        TrainerInfo = bp.TrainerInfo;
        LiveStats = bp.LiveStats;
        isShiny = bp.isShiny;
        Level = bp.Level;
        Stats = bp.Stats;

        /**/
        LiveStats.HP = bp.Kind.BaseStats.HPStat;
        LiveStats.Attack = bp.Kind.BaseStats.AttackStat;
        LiveStats.Defence = bp.Kind.BaseStats.DefenceStat;
        LiveStats.SpecialAttack = bp.Kind.BaseStats.SpAttackStat;
        LiveStats.SpecialDefence = bp.Kind.BaseStats.SpDefenceStat;
        LiveStats.Speed = bp.Kind.BaseStats.SpeedStat;
        /**/
    }

    public void GetXP()
    {

    }

    public void LvlUP()
    {

    }
}

[System.Serializable]
public class P_Trainer
{
    public string TrainerName;
    public int TrainerID;

    public string Place;
    public string Time;
}

[System.Serializable]
public class P_Stats
{
    public int HP;
    public int Attack;
    public int Defence;
    public int SpecialAttack;
    public int SpecialDefence;
    public int Speed;
}

[System.Serializable]
public class Live_Stats
{
    public int HP;
    //reset after battle
    public int Attack;
    public int Defence;
    public int SpecialAttack;
    public int SpecialDefence;
    public int Speed;
}