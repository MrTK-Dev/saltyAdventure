using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //Complete Item List & Bag
    public static GameObject activeBag;
    public static List<Item> activeItemList;
    public static int activeCapacity;

    //Bags
    public GameObject MedicineBag;
    public GameObject PokeballBag;

    #region Singleton

    //ItemChanged
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    //Bagswitched
    public delegate void OnBagSwitched();
    public OnBagSwitched OnBagSwitchedCallBack;

    public static InventoryManager instance;

    void Awake()
    {
        if (instance != null) {
            Debug.Log("There are more Inventories than there should be!");
            return;
        }

        instance = this;
    }

    #endregion

    //TODO
    //Bag Upgrades?
    
    //Complete Inventory List
    public List<Item> completeItemList;

    public bool Add(Item item, string category) {

        //check if Item is already in the Inventory
        bool InventoryhasItem = CheckInventoryList(item);

        SwitchActiveBag(null, category);

        if (item.StackSize < 99)
        {

            if (InventoryhasItem && item.StackSize <= 99)
            {
                //Increase StackSize
                IncreaseStackSize(item);

                //fire Event
                //return FirePickUpEvent();
                return true;
            }
            else
            {
                //Check Bag for Space
                if (activeItemList.Count < activeCapacity)
                {
                    //add item to Inventory List
                    completeItemList.Add(item);

                    //add item to bag
                    AddItemToBag(item, category);

                    //fire Event
                    //return FirePickUpEvent();
                    return true;
                }
                else
                {
                    Debug.Log("Not enough Inventory Space in " + category + " Bag.");
                    return false;
                }
            }

            /*bool FirePickUpEvent()
            {
                if (onItemChangedCallback != null)
                {
                    onItemChangedCallback.Invoke();
                }
                return true;
            }*/
        } else
        {
            return false;
        }
    }

    public void Remove(Item item) {
        //Fix Item Droping
        if (item.StackSize == 1)
        {
            //Change Highlight
            if (ItemHighlighting.instance.HighlightedItem != null)
            {
                if (activeItemList.Count > 1)
                {
                    int Index = activeItemList.IndexOf(item);

                    if (Index == 0 && activeItemList[1] != null)
                    {
                        ItemHighlighting.instance.UpdateHighlight(activeItemList[1]);
                    }
                    else if (activeItemList[Index - 1] != null)
                    {
                        ItemHighlighting.instance.UpdateHighlight(activeItemList[Index - 1]);
                    }
                }
                else
                {
                    //Clear Highlight if List is empty
                    ItemHighlighting.instance.CloseHighlight();
                }
            }
            //remove item from Lists
            completeItemList.Remove(item);
            activeItemList.Remove(item);

        } else
        {
            item.StackSize -= 1;
        }

        if (onItemChangedCallback != null) {
            onItemChangedCallback.Invoke();
        }
    }

    public void SwitchActiveBag(GameObject Bag, string Category)
    {
        if (Bag  == MedicineBag || Category == "Medicine")
        {
            activeBag = MedicineBag;
            activeItemList = MedicineBag.GetComponent<MedicineBag>().ItemList;
            activeCapacity = MedicineBag.GetComponent<MedicineBag>().SlotCapacity;
        } else if (Bag == PokeballBag || Category == "Pokeball")
        {
            activeBag = PokeballBag;
            activeItemList = PokeballBag.GetComponent<PokeballBag>().ItemList;
            activeCapacity = PokeballBag.GetComponent<PokeballBag>().SlotCapacity;
        }

        //fire event
        if (OnBagSwitchedCallBack != null)
        {
            OnBagSwitchedCallBack.Invoke();
        }
    }

    public void AddItemToBag(Item item, string category)
    {
        if (category == "Medicine")
        {
            activeItemList = MedicineBag.GetComponent<MedicineBag>().ItemList;
            activeItemList.Add(item);
        }
        else if (category == "Pokeball")
        {
            activeItemList = PokeballBag.GetComponent<PokeballBag>().ItemList;
            activeItemList.Add(item);
        }
    }

    bool CheckInventoryList(Item item)
    {
        return completeItemList.Contains(item);
    }

    void IncreaseStackSize(Item item)
    {
        Debug.Log("Increasing Stacksize of " + item.name + " from " + item.StackSize + " to " + (item.StackSize + 1));
        item.StackSize += 1;
    }

    public void FirePickUpEvent()
    {
        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }
}
