using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_UI : MonoBehaviour
{
    #region Singleton
    public static Shop_UI instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    #region Variables

    public UI_Components UI_Components;
    public UI_Selection UI_Selection;

    public Item_Item SelectedItem = Item_Item.none;
    public ShopData ActiveShop;
    GameObject newShopSlot;

    #endregion

    #region Methods

    public void OpenShopUI(Shop_Shop Shop)
    {
        if (Shop != Shop_Shop.none)
        {
            ShopData newShop = ShopData.GetData(Shop);

            if (ActiveShop != newShop)
                ActiveShop = newShop;

            UI_Components.UI.SetActive(true);
            UI_Components.Title.GetComponentInChildren<Text>().text = ActiveShop.Name;

            SetStock();
        }

        else
            Debug.Log(Shop.ToString() + " has not been set");
    }

    #endregion

    #region Stock Managment

    void SetStock()
    {
        ClearSlots();

        for (int i = 0; i < ActiveShop.Items.Count; i++)
        {
            newShopSlot = Instantiate(UI_Components.ShopSlot_PreFab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newShopSlot.transform.SetParent(UI_Components.ContentList);
            newShopSlot.GetComponent<ShopSlot>().AddItem(ItemData.GetData(ActiveShop.Items[i].Item));
        }
    }

    void ClearSlots()
    {
        for (int i = 0; i < UI_Components.ContentList.GetChildren().Count; i++)
        {
            Destroy(UI_Components.ContentList.GetChildren()[i]);
        }
    }

    #endregion

    #region Button Methods

    public void OnClickSelection(Item_Item Item)
    {
        if (SelectedItem != Item)
            SelectedItem = Item;

        //Logger.Debug(this.GetType().ToString(), Item.ToString() + " got selected in Shop Interface");

        ItemData ItemData = ItemData.GetData(Item);

        UI_Selection.Name.GetComponent<Text>().text = ItemData.Name;
        UI_Selection.Description.GetComponent<Text>().text = ItemData.Description;

        UI_Selection.Icon.GetComponent<Image>().sprite = ItemData.Icon;
        UI_Selection.Icon.GetComponent<Image>().enabled = true;

        //reset Quantity (+ price)
        //Selection.GetComponent<BuySell>().ResetQ(item.Price);

        //open Buy/Sell graphics
        //Selection.SetActive(true);
    }

    #endregion
}

#region SubClasses

[System.Serializable]
public class UI_Components
{
    public GameObject UI;
    public GameObject Title;
    public GameObject ShopSlot_PreFab;
    public Transform ContentList;
}

[System.Serializable]
public class UI_Selection
{
    public GameObject Name;
    public GameObject Description;
    public GameObject Stacksize;
    public GameObject Icon;
}

#endregion