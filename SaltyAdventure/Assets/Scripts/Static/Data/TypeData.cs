using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

[System.Serializable]
public class TypeData
{
    #region Variables

    public string Name = "Placeholder Name";
    public P_Type Type = P_Type.none;
    public string Hex = "#FFFFFF";
    public List<P_Type> EffectiveTo = new List<P_Type>();
    public List<P_Type> ResistedBy = new List<P_Type>();
    public List<P_Type> IneffectiveTo = new List<P_Type>();

    public static TypeData[] Database;

    #endregion

    #region Database

    static TypeData() => Database = new TypeData[]
    {
        new TypeData()
        {

        },

        new TypeData()
        {
            Name = "Normal",
            Type = P_Type.Normal,
            Hex = "A8A878",
            ResistedBy = new List<P_Type>()
            {
                P_Type.Rock, P_Type.Steel
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Ghost
            }
        },   //Normal
        new TypeData()
        {
            Name = "Fighting",
            Type = P_Type.Fighting,
            Hex = "C03028",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Normal, P_Type.Rock, P_Type.Steel, P_Type.Ice, P_Type.Dark
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Flying, P_Type.Poison, P_Type.Bug, P_Type.Psychic, P_Type.Fairy
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Ghost
            }
        },   //Fighting
        new TypeData()
        {
            Name = "Flying",
            Type = P_Type.Flying,
            Hex = "B09CF2",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Fighting, P_Type.Bug, P_Type.Grass
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Rock, P_Type.Steel, P_Type.Electric
            }
        },   //Flying
        new TypeData()
        {
            Name = "Poison",
            Type = P_Type.Poison,
            Hex = "A040A0",
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
        },   //Poison
        new TypeData()
        {
            Name = "Ground",
            Type = P_Type.Ground,
            Hex = "E6CE6C",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Poison, P_Type.Rock, P_Type.Steel, P_Type.Fire, P_Type.Electric
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Bug, P_Type.Grass
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Flying
            }
        },   //Ground
        new TypeData()
        {
            Name = "Rock",
            Type = P_Type.Rock,
            Hex = "B8A038",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Flying, P_Type.Bug, P_Type.Fire, P_Type.Ice
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Fighting, P_Type.Ground, P_Type.Steel
            }
        },   //Rock
        new TypeData()
        {
            Name = "Bug",
            Type = P_Type.Bug,
            Hex = "A8B820",
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
            Name = "Ghost",
            Type = P_Type.Ghost,
            Hex = "705898",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Ghost, P_Type.Psychic
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Dark
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Normal
            }
        },   //Ghost
        new TypeData()
        {
            Name = "Steel",
            Type = P_Type.Steel,
            Hex = "B8B8D0",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Rock, P_Type.Ice, P_Type.Fairy
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Steel, P_Type.Fire, P_Type.Water, P_Type.Electric
            }
        },   //Steel
        new TypeData()
        {
            Name = "Fire",
            Type = P_Type.Fire,
            Hex = "F08030",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Bug, P_Type.Steel, P_Type.Grass, P_Type.Ice
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Rock, P_Type.Fire, P_Type.Water, P_Type.Dragon
            }
        },   //Fire
        new TypeData()
        {
            Name = "Water",
            Type = P_Type.Water,
            Hex = "6890F0",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Ground, P_Type.Rock, P_Type.Fire
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Water, P_Type.Grass, P_Type.Dragon
            }
        },   //Water
        new TypeData()
        {
            Name = "Grass",
            Type = P_Type.Grass,
            Hex = "78C850",
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
            Name = "Electric",
            Type = P_Type.Electric,
            Hex = "F8D030",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Flying, P_Type.Water
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Grass, P_Type.Electric, P_Type.Dragon
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Ground
            }
        },   //Electric
        new TypeData()
        {
            Name = "Psychic",
            Type = P_Type.Psychic,
            Hex = "F85888",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Fighting, P_Type.Poison
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Steel, P_Type.Psychic
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Dark
            }
        },   //Psychic
        new TypeData()
        {
            Name = "Ice",
            Type = P_Type.Ice,
            Hex = "98D8D8",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Flying, P_Type.Ground, P_Type.Grass, P_Type.Dragon
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Steel, P_Type.Fire, P_Type.Water, P_Type.Ice
            }
        },   //Ice
        new TypeData()
        {
            Name = "Dragon",
            Type = P_Type.Dragon,
            Hex = "7038F8",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Dragon
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Steel
            },
            IneffectiveTo = new List<P_Type>()
            {
                P_Type.Fairy
            }
        },   //Dragon
        new TypeData()
        {
            Name = "Dark",
            Type = P_Type.Dark,
            Hex = "705848",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Ghost, P_Type.Psychic
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Fighting, P_Type.Dark, P_Type.Fairy
            }
        },   //Dark
        new TypeData()
        {
            Name = "Fairy",
            Type = P_Type.Fairy,
            Hex = "FF65D5",
            EffectiveTo = new List<P_Type>()
            {
                P_Type.Fighting, P_Type.Dragon, P_Type.Dark
            },
            ResistedBy = new List<P_Type>()
            {
                P_Type.Poison, P_Type.Steel, P_Type.Fire
            }
        },   //Fairy
    };

    #endregion

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

    public static Color GetColor(P_Type Type)
    {
        if (ColorUtility.TryParseHtmlString("#" + GetData(Type).Hex, out Color color))
            return color;

        else
        {
            Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, Type.ToString() + " does not have a valid Hex Color!");

            return color;
        }
    }

    #endregion
}
