using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class TypeData
{
    public string Name = "Placeholder Name";
    public P_Type Type = P_Type.none;
    public List<P_Type> EffectiveTo = new List<P_Type>();
    public List<P_Type> ResistedBy = new List<P_Type>();
    public List<P_Type> IneffectiveTo = new List<P_Type>();

    public static TypeData[] Database;

    static TypeData() => Database = new TypeData[]
    {
        new TypeData()
        {

        },

        new TypeData()
        {
            Name = "Bug",
            Type = P_Type.Bug,
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Grass, P_Type.Psychic, P_Type.Dark
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Fighting, P_Type.Flying, P_Type.Poison, P_Type.Ghost, P_Type.Steel, P_Type.Fire, P_Type.Fairy
            }
        },   //Bug
        new TypeData()
        {
            Name = "Grass",
            Type = P_Type.Grass,
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Ground, P_Type.Rock, P_Type.Water
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Flying, P_Type.Poison, P_Type.Bug, P_Type.Steel, P_Type.Fire, P_Type.Grass, P_Type.Dragon
            }
        },   //Grass
        new TypeData()
        {
            Name = "Poison",
            Type = P_Type.Poison,
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Grass, P_Type.Fairy
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Poison, P_Type.Ground, P_Type.Rock, P_Type.Ghost
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Steel
            }
        }   //Poison
    };

    #region Methods

    public static TypeData GetData(int Index)
    {
        return Database[Index];
    }

    public static TypeData GetData(P_Type Type)
    {
        for (int i = 0; i < Database.Length; i++)
        {
            if (Database[i].Type == Type)
            {
                return Database[i];
            }
        }

        Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, Type.ToString() + " is not yet in the Database!");
        return Database[0];
    }

    public static TypeData[] GetDatabase()
    {
        return Database;
    }

    #endregion
}
