using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Selector : MonoBehaviour
{
    //TODO find a better way
    #region Singleton

    public static Inventory_Selector instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Text ItemName;
    public Text ItemDescription;
    public Text ItemStacksize;
    public Image ItemIcon;

    public GameObject Buttons;

    public Item_Item ActiveItem = Item_Item.none;
    Item_Item[] CachedItems = new Item_Item[8];

    public void SelectItem(Item_Item Item)
    {
        if (ActiveItem != Item)
        {
            ActiveItem = Item;
            CacheItem(Item);

            ItemData ItemData = ItemData.GetData(Item);

            ItemName.text = ItemData.Name;
            ItemDescription.text = ItemData.Description;
            ItemStacksize.text = "x" + ItemData.Stacksize.ToString();

            ItemIcon.enabled = true;
            ItemIcon.sprite = ItemData.Icon;

            Buttons.SetActive(true);
        }
    }

    public void ClearSelection()
    {
        ActiveItem = Item_Item.none;

        ItemName.text = "";
        ItemDescription.text = "";
        ItemStacksize.text = "";

        ItemIcon.sprite = null;
        ItemIcon.enabled = false;

        Buttons.SetActive(false);
    }

    public void BagSwitch(BagData BagData)
    {
        if (BagData.Category != ItemData.GetData(ActiveItem).Category)
        {
            int Index = Inventory.ReturnIntFromCategory(BagData.Category);

            if (CachedItems[Index] != Item_Item.none && Inventory.ContainsItem(CachedItems[Index]))
                SelectItem(CachedItems[Index]);

            else if (BagData.List.Count > 0)
                SelectItem(BagData.List[0].Item);

            else
                ClearSelection();
        }
    }

    #region SubMethods

    void CacheItem(Item_Item Item)
    {
        int Index = Inventory.ReturnIntFromCategory(ItemData.GetData(Item).Category);

        if (CachedItems[Index] == Item)
            CachedItems[Index] = Item_Item.none;
        else
            CachedItems[Index] = Item;
    }

    #endregion
}
