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
    Potion
}

#endregion