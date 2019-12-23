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

    #endregion
}
