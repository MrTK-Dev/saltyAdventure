using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    #region Singleton

    public static InventoryController instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject InvScroll;

    public GameObject InventoryUI;
    public List<Item> FullItemList;

    public Transform BagParent;
    public List<GameObject> BagList;

    //bool firstActivation = true;

    private void Start()
    {
        BagList = BagParent.FindObjectsWithTag("Bag");
    }

    void Update()
    {
        //TODO
        //Check state

        if (Input.GetButtonDown("Inventory"))
        {
            InventoryUI.SetActive(!InventoryUI.activeSelf);
            /*if (firstActivation && InventoryUI.activeSelf)
            {
                InvScroll.GetComponent<InvScroll>().SetActiveBagList(BagList[0]);
                firstActivation = false;
            }*/
        }
    }

    public bool AddItemToInventory(Item newItem)
    {
        //check for Stacksize
        if (newItem.StackSize < 99)
        {
            //Check for if item is already in Itemlist
            if (FullItemList.Contains(newItem))
            {
                //stacksize +1 
                newItem.StackSize += 1;
                return true;
            }
            else
            {
                //add item to fulllist
                FullItemList.Add(newItem);

                //add item to baglist
                AddItemToBag(newItem);

                return true;
            }
        } else
        {
            return false;
        }
    }

    void AddItemToBag(Item newItem)
    {
        //Debug.Log("Trying to add " + newItem.name + " to a bag");
        for (int i = 0; i < BagList.Count; i++)
        {
            if (newItem.category == BagList[i].GetComponent<BagHandler>().Category)
            {
                BagList[i].GetComponent<BagHandler>().ItemList.Add(newItem);
            }
        }
    }

    public void RemoveItemFromInventory(Item newItem)
    {
        //Debug.Log("Trying to remove " + newItem.name + " from a bag");
        for (int i = 0; i < BagList.Count; i++)
        {
            if (newItem.category == BagList[i].GetComponent<BagHandler>().Category)
            {
                if (newItem.StackSize == 1)
                {
                    FullItemList.Remove(newItem);
                    BagList[i].GetComponent<BagHandler>().ItemList.Remove(newItem);
                } else
                {
                    newItem.StackSize -= 1;
                }
            }
        }
        InvScroll.GetComponent<InvScroll>().UpdateList();
    }

    public bool CheckIfPlayerHasItem(Item newItem)
    {
        return (FullItemList.Contains(newItem));
    }
}
