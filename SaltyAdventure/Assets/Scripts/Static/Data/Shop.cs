using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Shop
{
    public static List<Item_Item> Stock = new List<Item_Item>();
    public static ShopData ActiveShop;

    public static void SetActiveShop(Shop_Shop Shop)
    {
        if (ActiveShop != ShopData.GetData(Shop))
            ActiveShop = ShopData.GetData(Shop);
    }

    public static void BuyItem(Item_Item Item, int Count)
    {

    }
}
