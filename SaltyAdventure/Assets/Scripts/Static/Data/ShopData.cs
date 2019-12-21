using System.Collections;
using System.Collections.Generic;

public class ShopData
{
    #region Variables

    public Shop_Shop Shop = Shop_Shop.none;
    public Shop_Category Category = Shop_Category.none;
    public string Name = "Shop.Name";
    public string Description = "Shop.Description";
    public List<Shop_Tree> Items = new List<Shop_Tree>()
    {

    };

    #endregion

    #region Database

    public static ShopData[] Database;
    static ShopData() => Database = new ShopData[]
    {
        new ShopData()
        {

        },

        new ShopData()
        {
            Shop = Shop_Shop.Market_0,
            Category = Shop_Category.Market,
            Name = "Market",
            Description = "A Market for everyone",
            Items = new List<Shop_Tree>()
            {
                new Shop_Tree()
                {
                    Item = Item_Item.Potion/*,
                    Price = ItemData.GetData(Item_Item.Potion).Price*/
                },
                new Shop_Tree()
                {
                    Item = Item_Item.Antidote,
                    Price = ItemData.GetData(Item_Item.Antidote).Price
                },
                new Shop_Tree()
                {
                    Item = Item_Item.Awakening,
                    Price = ItemData.GetData(Item_Item.Awakening).Price
                },
                new Shop_Tree()
                {
                    Item = Item_Item.HyperPotion,
                    Price = ItemData.GetData(Item_Item.HyperPotion).Price
                }
            }
        }

    };

    #endregion

    #region Methods

    public static void SetPrice()
    {
        for (int i = 0; i < Database.Length; i++)
        {
            for (int j = 0; j < Database[i].Items.Count; j++)
            {
                if (Database[i].Items[j].Price == 0)
                    Database[i].Items[j].Price = ItemData.GetData(Database[i].Items[j].Item).Price;
            }
        }
    }

    public static ShopData GetData(Shop_Shop Shop)
    {
        SetPrice();

        for (int i = 0; i < Database.Length; i++)
        {
            if (Database[i].Shop == Shop)
                return Database[i];
        }

        throw new System.Exception(Shop.ToString() + " doesn't exist yet in the Database");
    }

    #endregion
}

public class Shop_Tree
{
    public Item_Item Item;
    public int Price = 0;
}

#region Enums

public enum Shop_Category
{
    none,
    Market
}

public enum Shop_Shop
{
    none,
    Market_0
}

#endregion