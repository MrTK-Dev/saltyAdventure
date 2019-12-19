using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    static public List<ItemData> FullList = new List<ItemData>();

    #region Checks

    static public bool ContainsItem(Item_Item Item)
    {
        return FullList.Contains(ItemData.GetData(Item));
    }

    static public bool ContainsItem(Item_Item Item, int Count)
    {
        return (ContainsItem(Item) && ItemData.GetData(Item).Stacksize >= Count);
    }

    #endregion

    #region Methods

    static public bool AddItem(Item_Item Item)
    {
        ItemData Item_Data = ItemData.GetData(Item);

        if (ContainsItem(Item) && Item_Data.Stacksize < Item_Data.maxStack)
        {
            Item_Data.Stacksize++;

            return true;
        }

        else if (!ContainsItem(Item))
        {
            FullList.Add(Item_Data);

            for (int i = 0; i < BagData.Database.Length; i++)
            {
                if (BagData.Database[i].Category == Item_Data.Category)
                    BagData.Database[i].List.Add(Item_Data);
            }

            return true;
        }

        else
        {
            Debug.Log("Not enough space for " + Item_Data.Name);
            return false;
        }
    }

    static public void RemoveItem(Item_Item Item)
    {
        ItemData Item_Data = ItemData.GetData(Item);

        if (!ContainsItem(Item))
            throw new System.Exception(Item_Data.Name + " doesn't exist in the Inventory.");

        else
        {
            if (Item_Data.Stacksize > 1)
                Item_Data.Stacksize--;

            else
            {
                FullList.Remove(Item_Data);

                for (int i = 0; i < BagData.Database.Length; i++)
                {
                    if (BagData.Database[i].Category == Item_Data.Category)
                        BagData.Database[i].List.Remove(Item_Data);
                }
            }
        }
    }

    static public void FavItem(Item_Item Item)
    {
        ItemData ItemData = ItemData.GetData(Item);
        BagData BagData = BagData.GetBag(Item_Category.none);

        if (BagData.List.Contains(ItemData))
            BagData.List.Remove(ItemData);
        else
            BagData.List.Add(ItemData);
    }

    #endregion

    #region Conversion

    static public int ReturnIntFromCategory(Item_Category Category)
    {
        switch (Category)
        {
            case Item_Category.Medicine:
                return 0;
            case Item_Category.Items:
                return 1;
            case Item_Category.Pokeball:
                return 2;
            case Item_Category.TM:
                return 3;
            case Item_Category.Battle:
                return 4;
            case Item_Category.Berries:
                return 5;
            case Item_Category.Key:
                return 6;
            case Item_Category.none:
                return 7;

            default:
                return 0;
        }
    }

    #endregion
}