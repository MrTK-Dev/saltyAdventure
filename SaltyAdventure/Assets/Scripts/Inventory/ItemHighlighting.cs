using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHighlighting : MonoBehaviour
{
    //TODO
    //buttons to switch for more items [or] scrolling

    #region Singleton

    public static ItemHighlighting instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    Text[] TextList;
    Image[] SpriteList;

    public Item HighlightedItem;

    string ItemNameSlot;
    string ItemDescriptionSlot;
    string ItemCountSlot;
    Sprite ItemIconSlot;

    Item MedicineItem;
    Item PokeballItem;

    void Start()
    {
        TextList = GetComponentsInChildren<Text>();
        SpriteList = GetComponentsInChildren<Image>();
        CloseHighlight();
    }

    public void UpdateHighlight(Item item)
    {
        HighlightedItem = item;

        if (item != null)
        {
            if (item.category == "Medicine")
            {
                MedicineItem = item;
            } else if (item.category == "Pokeball")
            {
                PokeballItem = item;
            }

            SpriteList[1].enabled = true;
            
            ItemNameSlot = item.name;
            ItemDescriptionSlot = item.description;
            ItemIconSlot = item.icon;
            ItemCountSlot = item.StackSize.ToString();

            TextList[0].text = ItemNameSlot;
            TextList[1].text = ItemDescriptionSlot;
            TextList[2].text = ItemCountSlot;
            SpriteList[1].sprite = ItemIconSlot;
        }
    }

    public void CloseHighlight()
    {
        TextList[0].text = null;
        TextList[1].text = null;
        TextList[2].text = null;
        SpriteList[1].sprite = null;

        SpriteList[1].enabled = false;
    }

    
    public void ChangeHighlightedBag()
    {
        if (InventoryManager.activeBag == InventoryManager.instance.MedicineBag && MedicineItem != null && InventoryManager.activeItemList.Contains(MedicineItem))
        {
            UpdateHighlight(MedicineItem);
            Debug.Log("loaded Item from Cache");
        }
        else if(InventoryManager.activeBag == InventoryManager.instance.PokeballBag && PokeballItem != null && InventoryManager.activeItemList.Contains(PokeballItem))
        {
            UpdateHighlight(PokeballItem);
        }
        else
        {
            CloseHighlight();
        }
    }
}
