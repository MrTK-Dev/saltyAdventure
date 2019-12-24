using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class Natures
{
    /// <summary>
    /// Checks if the given Stat is set in the given Nature.
    /// Returns '0.9 | 1.0 | 1.1'.
    /// </summary>
    /// <param name="Nature">Nature</param>
    /// <param name="Stat">Stat</param>
    /// <returns>Value</returns>
    public static float GetValue(P_Nature Nature, P_Stats_All Stat)
    {
        NatureData NData = NatureData.GetData(Nature);

        if (NData.IncreasedStat == Stat)
            return 1.1f;

        else if (NData.DecreasedStat == Stat)
            return 0.9f;

        return 1f;
    }

    /// <summary>
    /// Returns a random Nature from the Database.
    /// Starts at 1 because of the placeholder
    /// </summary>
    /// <returns>random Nature</returns>
    public static P_Nature GetRandomNature()
    {
        return NatureData.GetData(Random.Range(1, NatureData.GetDatabase().Length - 1)).Nature;
    }
}

[System.Serializable]
public class NatureData
{
    public string Name = "Placeholder Name";
    public P_Nature Nature = P_Nature.none;
    public P_Stats_All IncreasedStat = P_Stats_All.none;
    public P_Stats_All DecreasedStat = P_Stats_All.none;
    //Flavors by check

    public static NatureData[] Database;

    #region Database

    static NatureData()
    {
        Database = new NatureData[]
        {
            new NatureData()
            {

            },

            new NatureData()
            {
                Name = "Hardy",
                Nature = P_Nature.Hardy,
                IncreasedStat = P_Stats_All.none,
                DecreasedStat = P_Stats_All.none
            },
            new NatureData()
            {
                Name = "Lonely",
                Nature = P_Nature.Lonely,
                IncreasedStat = P_Stats_All.Attack,
                DecreasedStat = P_Stats_All.Defense
            },
            new NatureData()
            {
                Name = "Brave",
                Nature = P_Nature.Brave,
                IncreasedStat = P_Stats_All.Attack,
                DecreasedStat = P_Stats_All.Speed
            }
        };
    }

    #endregion

    #region Methods

    public static NatureData GetData(int Index)
    {
        return Database[Index];
    }

    public static NatureData GetData(P_Nature Nature)
    {
        for (int i = 0; i < Database.Length; i++)
        {
            if (Database[i].Nature == Nature)
            {
                return Database[i];
            }
        }

        Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, Nature.ToString() + " is not yet in the Database!");
        return Database[0];
    }

    public static NatureData[] GetDatabase()
    {
        return Database;
    }

    #endregion
}

/*
    Nature	Japanese	Increased stat	Decreased stat	Favorite flavor	Disliked flavor
    0	Hardy	がんばりや	—	—	—	—
    1	Lonely	さみしがり	Attack	Defense	Spicy	Sour
    2	Brave	ゆうかん	Attack	Speed	Spicy	Sweet
    3	Adamant	いじっぱり	Attack	Sp. Attack	Spicy	Dry
    4	Naughty	やんちゃ	Attack	Sp. Defense	Spicy	Bitter
    5	Bold	ずぶとい	Defense	Attack	Sour	Spicy
    6	Docile	すなお	—	—	—	—
    7	Relaxed	のんき	Defense	Speed	Sour	Sweet
    8	Impish	わんぱく	Defense	Sp. Attack	Sour	Dry
    9	Lax	のうてんき	Defense	Sp. Defense	Sour	Bitter
    10	Timid	おくびょう	Speed	Attack	Sweet	Spicy
    11	Hasty	せっかち	Speed	Defense	Sweet	Sour
    12	Serious	まじめ	—	—	—	—
    13	Jolly	ようき	Speed	Sp. Attack	Sweet	Dry
    14	Naive	むじゃき	Speed	Sp. Defense	Sweet	Bitter
    15	Modest	ひかえめ	Sp. Attack	Attack	Dry	Spicy
    16	Mild	おっとり	Sp. Attack	Defense	Dry	Sour
    17	Quiet	れいせい	Sp. Attack	Speed	Dry	Sweet
    18	Bashful	てれや	—	—	—	—
    19	Rash	うっかりや	Sp. Attack	Sp. Defense	Dry	Bitter
    20	Calm	おだやか	Sp. Defense	Attack	Bitter	Spicy
    21	Gentle	おとなしい	Sp. Defense	Defense	Bitter	Sour
    22	Sassy	なまいき	Sp. Defense	Speed	Bitter	Sweet
    23	Careful	しんちょう	Sp. Defense	Sp. Attack	Bitter	Dry
 */
