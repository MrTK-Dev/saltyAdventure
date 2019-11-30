using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHighlight : MonoBehaviour
{
    #region Singleton

    public static ItemHighlight instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    public Transform BagParent;
    List<GameObject> BagList;

    public GameObject InvScroll;
    public GameObject Buttons;

    public Text ItemName;
    public Text ItemDescription;
    public Text ItemStacksize;

    public Image ItemIcon;
    
    Item HighlightedItem;

    void Start()
    {
        BagList = BagParent.FindObjectsWithTag("Bag");
    }

    public void HighlightItem(Item newItem)
    {
        HighlightedItem = newItem;

        ItemName.text = newItem.name;
        ItemDescription.text = newItem.description;
        ItemStacksize.text = "x" + newItem.StackSize.ToString();

        ItemIcon.enabled = true;
        ItemIcon.sprite = newItem.icon;

        Buttons.SetActive(true);    //activate Usage buttons
        if (newItem.category == "Key")
        {
            Buttons.GetComponent<UsageButtonCtrl>().UsusButtusListus[1].SetActive(true);
        } else
        {
            Buttons.GetComponent<UsageButtonCtrl>().UsusButtusListus[1].SetActive(false);
        }
            
        CacheItem(newItem);
    }

    public void clearHighlight()    //clear all things from the highlighter
    {
        ItemName.text = "";
        ItemDescription.text = "";
        ItemStacksize.text = "";

        ItemIcon.sprite = null;
        ItemIcon.enabled = false;

        Buttons.SetActive(false);
    }

    //Caching
    void CacheItem(Item newItem)
    {
        for (int i = 0; i < BagList.Count; i++)
        {
            if(BagList[i].GetComponent<BagHandler>().Category == newItem.category)
            {
                BagList[i].GetComponent<BagHandler>().CachedItem = newItem;
            }
        }
    }

    public void UpdateAfterBagSwitch(GameObject Bag)
    {
        //switches highlight to cached item
        if(Bag.GetComponent<BagHandler>().CachedItem != null && Bag.GetComponent<BagHandler>().ItemList.Contains(Bag.GetComponent<BagHandler>().CachedItem))
        {
            HighlightItem(Bag.GetComponent<BagHandler>().CachedItem);
        } else if (Bag.GetComponent<BagHandler>().CachedItem == null || !Bag.GetComponent<BagHandler>().ItemList.Contains(Bag.GetComponent<BagHandler>().CachedItem))
        {
            //check if highlight may switch to first item in List
            if (Bag.GetComponent<BagHandler>().ItemList.Count > 0)
            {
                HighlightItem(Bag.GetComponent<BagHandler>().ItemList[0]);
            }
            else
            {
                clearHighlight();
            }
        }
    }

    public void RemoveButton()
    {
        if (HighlightedItem != null)
        {
            if (HighlightedItem.StackSize == 1)
            {
                //Index = Position counted from 0 to ...
                int Index = InvScroll.GetComponent<InvScroll>().activeItemList.IndexOf(HighlightedItem);
                int Count = InvScroll.GetComponent<InvScroll>().activeItemList.Count;

                Item deletItem = HighlightedItem;

                if (Count > (Index + 1))    //check if item != null on next index
                {
                    HighlightItem(InvScroll.GetComponent<InvScroll>().activeItemList[Index + 1]);
                }   
                else if (Count == (Index + 1) && Count > 1 && Index > 0)    //check if there is an item in front of the item in the list
                {
                    HighlightItem(InvScroll.GetComponent<InvScroll>().activeItemList[Index - 1]);
                }
                else    //clear highlight
                {
                    clearHighlight();
                }

                //remove item
                InventoryController.instance.RemoveItemFromInventory(deletItem);

            } else    //update stacksize
            {
                ItemStacksize.text = "x" + (HighlightedItem.StackSize - 1).ToString();
                InventoryController.instance.RemoveItemFromInventory(HighlightedItem);
            }
        }
    }
}
