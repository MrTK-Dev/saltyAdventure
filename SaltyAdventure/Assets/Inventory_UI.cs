using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public GameObject UI;
    public GameObject InventorySlotPreFab;
    public GameObject ContentList;
    public GameObject Selection;

    public BagData ActiveBag;

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            UI.SetActive(!UI.activeSelf);
            UpdateActiveList();
        }
    }

    public void UpdateActiveList()
    {
        for (int i = 0; i < ContentList.transform.FindObjectsWithTag("ItemSlot").Count; i++)
        {
            Destroy(ContentList.transform.FindObjectsWithTag("ItemSlot")[i]);
        }

        if (ActiveBag == null)
        {
            ActiveBag = BagData.GetBag(Item_Category.Medicine);
        }

        //Spawn ItemSlots + add Items
        for (int i = 0; i < ActiveBag.List.Count; i++)
        {
            GameObject newInvSlot = Instantiate(InventorySlotPreFab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            newInvSlot.transform.SetParent(ContentList.transform);
            newInvSlot.GetComponent<InventorySlot>().AddItem(ActiveBag.List[i]);
        }
    }

    public void SetActiveBag(Item_Category Category)
    {
        SetActiveBag(BagData.GetBag(Category));
    }
    public void SetActiveBag(BagData Bag)
    {
        if (ActiveBag != Bag)
        {
            ActiveBag = Bag;

            UpdateActiveList();

            Selection.GetComponent<Inventory_Selector>().BagSwitch(Bag);
        }
    }
}
