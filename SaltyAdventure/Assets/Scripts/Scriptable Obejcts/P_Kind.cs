﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
[CreateAssetMenu(fileName = "New Poke", menuName = "SO/Pokemon/Kind")]
public class P_Kind : ScriptableObject
{
    public P_Information GeneralInformation;

    public P_Pokedex_Entry PokedexEntry;

    public P_BaseStats BaseStats;

    public P_Evolution Evolution;

    public P_Moves Moves;

    public P_Breeding Breeding;
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
public class P_Pokedex_Entry
{
    public int Index;
    public string Description;
}

[System.Serializable]
public class P_Evolution
{
    public bool canEvolve;
    public int Evo_LvL;
    public P_Kind E_Kind;
}

[System.Serializable]
public class P_Information
{
    public string KindName;
    public Sprite Icon;
    public Sprite IconShiny;
    public P_Type TypePrimus;
    public P_Type TypeSecundus;
}

[System.Serializable]
public class P_Moves
{
    public List<P_Move> Lvl;
    public int[] LvlUP;

    public List<P_Move> TM;
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

    public float HatchTime;
    public P_EggGroup[] EggGroups;
}

[System.Serializable]
public enum P_EggGroup
{
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
*/

/*
 * Pokemon Kind
 * - Type
 * [Abilites, Moves, BaseStats]
 * 
 * Reference to Trainer
 * - Nickname
 * - Herkunft (place, time)
 * 
 * Stats
 * - max- / curHP
 * - (Spez-)Attack
 * - (Spez-)Defense
 * - Speed
 * 
 * Ability
 * 
 * Held Item
 * 
 * Moves
 * {
 *  [ph or spez]
 *  [dmg or not]
 *  [spezial feature]
 *  [AP]
 * }
 */
