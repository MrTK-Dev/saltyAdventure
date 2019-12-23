using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class StatCalculator
{
    static int CalculateStat(P_Stats_All Stat, int Base, int DV, int EV, int Level, P_Nature Nature)
    {
        float Value;

        if (Stat == Stats[0])
            Value = ((2 * Base + DV + (EV / 4)) * Level / 100) + Level + 10;

        else
            Value = (((2 * Base + DV + (EV / 4)) * Level / 100) + 5) * Natures.GetValue(Nature, Stat);

        return Mathf.FloorToInt(Value);
    }

    public static List<int> CalculateStats(BasePokemon Pokemon)
    {
        List<int> CalculatedStats = new List<int>();

        P_BaseStats BaseStats = PokemonData.GetData(Pokemon.Monster).BaseStats;
        DeterminantValues DValues = Pokemon.DValues;
        EffortValues EValues = Pokemon.EValues;
        P_Nature Nature = Pokemon.Nature;
        int Level = Pokemon.Level;

        int Base = 0;
        int DV = 0;
        int EV = 0;
        
        foreach (P_Stats_All Stat in Stats)
        {
            switch (Stat)
            {
                case P_Stats_All.HP:
                    Base = BaseStats.HP;
                    DV = DValues.HP;
                    EV = EValues.HP;
                    break;

                case P_Stats_All.Attack:
                    Base = BaseStats.Attack;
                    DV = DValues.Attack;
                    EV = EValues.Attack;
                    break;

                case P_Stats_All.Defense:
                    Base = BaseStats.Defense;
                    DV = DValues.Defense;
                    EV = EValues.Defense;
                    break;

                case P_Stats_All.SpecialAttack:
                    Base = BaseStats.SpecialAttack;
                    DV = DValues.SpecialAttack;
                    EV = EValues.SpecialAttack;
                    break;

                case P_Stats_All.SpecialDefense:
                    Base = BaseStats.SpecialDefense;
                    DV = DValues.SpecialDefense;
                    EV = EValues.SpecialDefense;
                    break;

                case P_Stats_All.Speed:
                    Base = BaseStats.Speed;
                    DV = DValues.Speed;
                    EV = EValues.Speed;
                    break;

                default:
                    Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, "'" + Stat + "' is not a valid Input for Stat Calculation!");
                    break;
            }

            CalculatedStats.Add(CalculateStat(Stat, Base, DV, EV, Level, Nature));
        };

        return CalculatedStats;
    }

    static readonly P_Stats_All[] Stats = new P_Stats_All[]
    {
        P_Stats_All.HP,
        P_Stats_All.Attack,
        P_Stats_All.Defense,
        P_Stats_All.SpecialAttack,
        P_Stats_All.SpecialDefense,
        P_Stats_All.Speed
    };
}

#region Enums

[System.Serializable]
public enum P_Stats_All
{
    none,
    HP,
    Attack,
    Defense,
    SpecialAttack,
    SpecialDefense,
    Speed
}

#endregion