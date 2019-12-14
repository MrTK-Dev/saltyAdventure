using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePokemon : MonoBehaviour
{
    public string Name;

    public P_Kind Kind;

    public Item HeldItem;

    public P_Trainer TrainerInfo;

    public Live_Stats LiveStats;

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

public class Live_Stats
{
    public int HP;
    public int Attack;
    public int Defence;
    public int SpecialAttack;
    public int SpecialDefence;
    public int Speed;
}