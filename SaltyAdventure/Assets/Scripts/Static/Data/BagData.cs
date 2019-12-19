using System.Collections;
using System.Collections.Generic;

public class BagData
{
    #region Variables

    public Item_Category Category = Item_Category.none;
    public string Name = "Bag.Name";
    public string Description = "Bag.Description";
    public List<ItemData> List;

    #endregion

    #region Database

    public static BagData[] Database;
    static BagData() => Database = new BagData[]
    {
        new BagData()
        {
            Category = Item_Category.Medicine,
            Name = "Medicine",
            Description = "Diggi Medicine",
            List = new List<ItemData>()
            {

            }
        },
        new BagData()
        {
            Category = Item_Category.Items,
            Name = "Items",
            Description = "Diggi Items",
            List = new List<ItemData>()
            {

            }
        },
        new BagData()
        {
            Category = Item_Category.Pokeball,
            Name = "Pokeballs",
            Description = "Diggi Pokeballs",
            List = new List<ItemData>()
            {

            }
        },
        new BagData()
        {
            Category = Item_Category.TM,
            Name = "TMs",
            Description = "Diggi TMs",
            List = new List<ItemData>()
            {

            }
        },
        new BagData()
        {
            Category = Item_Category.Battle,
            Name = "Battle Items",
            Description = "Diggi Battle Items",
            List = new List<ItemData>()
            {

            }
        },
        new BagData()
        {
            Category = Item_Category.Berries,
            Name = "Berries",
            Description = "Diggi Berries",
            List = new List<ItemData>()
            {

            }
        },
        new BagData()
        {
            Category = Item_Category.Key,
            Name = "Key Items",
            Description = "Diggi Key Items",
            List = new List<ItemData>()
            {

            }
        },
        new BagData()
        {
            Category = Item_Category.none,
            Name = "FAV",
            Description = "Diggi FAV Items",
            List = new List<ItemData>()
            {

            }
        }
    };

    #endregion

    #region Methods

    static public BagData GetBag(Item_Category Category)
    {
        for (int i = 0; i < Database.Length; i++)
        {
            if (Database[i].Category == Category)
                return Database[i];
        }

        throw new System.Exception(Category.ToString() + " does not match any type of existing Bag.");
    }

    #endregion
}
