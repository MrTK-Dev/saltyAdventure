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
}
