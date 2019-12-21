using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopController : MonoBehaviour
{
    #region Singleton
    public static ShopController instance;

    void Awake()
    {
        instance = this;
    }

    #endregion


    public GameObject Selection;
    public GameObject UI;
    public Transform ContentList;

    public GameObject ShopSlotPreFab;
    GameObject newShopSlot;

    public Text Title;
    //public Shop activeShop;

    //Highlight
    public Item HItem;
    public Text HName;
    public Text HDesc;
    public Text HStacksize;
    public Image HIcon;

    //Buy <-> Sell
    public bool ModeBuying = true;
    public Text SwitchButton;

    /*public void OpenShopUI(Shop shop)
    {
        //cache shop
        activeShop = shop;

        UI.SetActive(true);

        Title.text = shop.Name;

        SetItemList(shop);

        //reset to 1st item in list
        ChooseItem(shop.Stock[0]);
    }*/

    void ClearSlots()
    {
        for (int i = 0; i < ContentList.FindObjectsWithTag("ShopSlot").Count; i++)
        {
            Destroy(ContentList.FindObjectsWithTag("ShopSlot")[i]);
        }
    }

    /*void SetItemList(Shop shop)
    {
        //clear list
        ClearSlots();

        //Spawn ItemSlots + add Items
        for (int i = 0; i < shop.Stock.Count; i++)
        {
            newShopSlot = Instantiate(ShopSlotPreFab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newShopSlot.transform.SetParent(ContentList);
            newShopSlot.GetComponent<ShopSlot>().AddItem(shop.Stock[i]);
        }
    }*/

    public void ChooseItem(Item item)
    {
        HItem = item;

        HIcon.enabled = true;

        HName.text = item.name;
        HDesc.text = item.description;
        HIcon.sprite = item.icon;

        //reset Quantity (+ price)
        Selection.GetComponent<BuySell>().ResetQ(item.Price);

        //open Buy/Sell graphics
        Selection.SetActive(true);
    }

    public void CloseShop()
    {
        UI.SetActive(false);
        Selection.SetActive(false);
    }

    public void SwitchBetweenModes()
    {
        if (ModeBuying)
        {
            Switch2Sell();
        }
        else
        {
            //To Do
            //change later
            ModeBuying = true;
            SwitchButton.text = "Sell [WIP]";

            //OpenShopUI(activeShop);
        }
    }

    void Switch2Sell()
    {
        ModeBuying = false;
        SwitchButton.text = "Buy";

        //change itemlist
        ClearSlots();
        for (int i = 0; i < InventoryController.instance.FullItemList.Count; i++)
        {
            if (InventoryController.instance.FullItemList[i].category != "Key")
            {
                newShopSlot = Instantiate(ShopSlotPreFab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                newShopSlot.transform.SetParent(ContentList);
                newShopSlot.GetComponent<ShopSlot>().AddItem(InventoryController.instance.FullItemList[i]);
            }
        }
    }
}
