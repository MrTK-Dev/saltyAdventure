using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvScroll : MonoBehaviour
{
    public GameObject activeBag;
    public List<Item> activeItemList;

    public GameObject InventorySlotPreFab;
    GameObject newInvSlot;
    public Transform ContentList;

    public void SetActiveBagList(GameObject Bag)
    {
        activeBag = Bag;
        activeItemList = Bag.GetComponent<BagHandler>().ItemList;

        UpdateList();
    }

    public void UpdateList()
    {
        //clear list
        for (int i = 0; i < ContentList.FindObjectsWithTag("ItemSlot").Count; i++)
        {
            Destroy(ContentList.FindObjectsWithTag("ItemSlot")[i]);
        }

        //Spawn ItemSlots + add Items
        for (int i = 0; i < activeItemList.Count; i++)
        {
            newInvSlot = Instantiate(InventorySlotPreFab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newInvSlot.transform.SetParent(ContentList);
            newInvSlot.GetComponent<InventorySlot>().AddItem(activeItemList[i]);
        }
    }




    /*public void UpdateList()
    {
        ClearSlots();
        SpawnSlots();
        AddItems(0);
    }


    void SpawnSlots()
    {
        for (int i = 0; i < 4; i++)
        {
            newInvSlot = Instantiate(InventorySlotPreFab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newInvSlot.transform.SetParent(ContentList);
            //newInvSlot.GetComponent<InventorySlot>().AddItem(activeItemList[i]);
        }
    }

    void ClearSlots()
    {
        for (int i = 0; i < ContentList.FindObjectsWithTag("ItemSlot").Count; i++)
        {
            Destroy(ContentList.FindObjectsWithTag("ItemSlot")[i]);
        }
    }

    void AddItems(int StartIndex)
    {
        for (int i = 0; i < ContentList.FindObjectsWithTag("ItemSlot").Count; i++)
        {
            if (activeItemList.Count > StartIndex + i)
            ContentList.FindObjectsWithTag("ItemSlot")[i].GetComponent<InventorySlot>().AddItem(activeItemList[StartIndex + i]);
        }
    }

    int getIndex(Item newItem)  //Item list
    {
        return activeItemList.IndexOf(newItem);
    }

    Item GetItemFromIndex(int Index)    //Inventory Slots
    {
        return ContentList.FindObjectsWithTag("ItemSlot")[Index].GetComponent<InventorySlot>().item;
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) //Up
        {
            if (activeItemList.Count > 4 && getIndex(GetItemFromIndex(0)) != 0)
            {
                AddItems(getIndex(GetItemFromIndex(0)) - 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.J)) //Down
        {
            if (activeItemList.Count > 4 && getIndex(GetItemFromIndex(3)) != activeItemList.Count - 1)
            {
                AddItems(getIndex(GetItemFromIndex(0)) + 1);
            }
        }
    }*/
}
