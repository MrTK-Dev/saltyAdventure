using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Class functions purely as a JSON-Helper.
/// </summary>
public class ItemDataBase
{
    public ItemData[] ItemData;
}
public class ItemData
{
    #region Variables

    public Item_Item Item = Item_Item.none;
    public string Name = "Placeholder Name";
    public string Description = "Placeholder Description";
    public Item_Category Category = Item_Category.none;
    public int ID = -1;
    public Sprite Icon;
    public int Stacksize = 1;
    public int maxStack = 99;
    /// <summary>
    /// If Price <= 0 -> Item is not for purchase.
    /// </summary>
    public int Price = 0;
    /// <summary>
    /// If SellPrice <= 0 -> Item is not sellable.
    /// </summary>
    public int SellPrice = 0;

    #endregion

    public static int Count { get { return Database.Length; } }
    public static ItemData[] Database;

    #region Database

    static ItemData() => Database = new ItemData[]
    {
        new ItemData()
        {
            ID = 0
        },

        new ItemData()
        {
            Item = Item_Item.Potion,
            Name = "Potion",
            Description = "Heals the Pokemon by 20 HP",
            Category = Item_Category.Medicine,
            ID = 1,
            Price = 200,
            SellPrice = 50
        },
        new ItemData()
        {
            Item = Item_Item.Antidote,
            Name = "Antidote",
            Description = "A spray-type medicine for treating poisoning. It can be used to lift the effects of being poisoned from a single Pokémon.",
            Category = Item_Category.Medicine,
            ID = 2,
            Price = 300,
            SellPrice = 75
        },
        new ItemData()
        {
            Item = Item_Item.Awakening,
            Name = "Awakening",
            Description = "A spray-type medicine to wake the sleeping. It can be used to rouse a single Pokémon from the clutches of sleep.",
            Category = Item_Category.Medicine,
            ID = 3,
            Price = 250,
            SellPrice = 50
        },
        new ItemData()
        {
            Item = Item_Item.Pokeball,
            Name = "Pokeball",
            Description = "A device for catching wild Pokémon. It's thrown like a ball at a Pokémon, comfortably encapsulating its target.",
            Category = Item_Category.Pokeball,
            ID = 4,
            Price = 200,
            SellPrice = 50
        },
        new ItemData()
        {
            Item = Item_Item.FullRestore,
            Name = "Full Restore",
            Description = "A medicine that can be used to fully restore the HP of a single Pokémon and heal any status conditions it has.",
            Category = Item_Category.Medicine,
            ID = 5,
            Price = 3000,
            SellPrice = 1000
        },
        new ItemData()
        {
            Item = Item_Item.HyperPotion,
            Name = "Hyper Potion",
            Description = "A spray-type medicine for treating wounds. It can be used to restore 120 HP to a single Pokémon.",
            Category = Item_Category.Medicine,
            ID = 6,
            Price = 1500,
            SellPrice = 250
        },
        new ItemData()
        {
            Item = Item_Item.UltraBall,
            Name = "Ultra Ball",
            Description = "An ultra-high performance Poké Ball that provides a higher success rate for catching Pokémon than a Great Ball.",
            Category = Item_Category.Pokeball,
            ID = 7,
            Price = 1200,
            SellPrice = 400
        }
    };

    #endregion

    #region Functions

    public static ItemData GetData(int Index)
    {
        return Database[Index];
    }

    public static ItemData GetData(Item_Item Item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Database[i].Item == Item)
            {
                return Database[i];
            }
        }

        return Database[0];
    }

    public static ItemData[] GetDatabase()
    {
        return Database;
    }

    #endregion
}

#region Enums

public enum Item_Category
{
    none,
    Medicine,
    Items,
    Pokeball,
    TM,
    Battle,
    Berries,
    Key
}

public enum Item_Item   //change to Item
{
    none,
    Potion,
    Antidote,
    Awakening,
    Pokeball,
    FullRestore,
    HyperPotion,
    UltraBall,



    LuckyEgg
}

#endregion