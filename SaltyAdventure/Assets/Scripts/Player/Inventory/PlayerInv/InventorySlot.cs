using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public GameObject Selection;

    public Image icon;
    public Button removeButton;
    public Text textField;
    public Text ItemCount;
    public Image ButtonBG;

    public Item_Item Item;

    public void AddItem(ItemData newItem)
    {
        Item = newItem.Item;

        icon.sprite = newItem.Icon;
        icon.enabled = true;

        removeButton.interactable = true;
        ButtonBG.enabled = true;

        //change textfields
        textField.text = newItem.Name;
        ItemCount.text = "x " + newItem.Stacksize.ToString();

        GetComponentInChildren<Image>().enabled = true;
    }

    public void AddItem(Item_Item newItem)
    {
        AddItem(ItemData.GetData(newItem));
    }

    public void ClearSlot()
    {
        Item = Item_Item.none;

        icon.sprite = null;
        icon.enabled = false;
        textField.text = null;
        ItemCount.text = null;

        removeButton.interactable = false;
        ButtonBG.enabled = false;
    }

    public void HighlightItem()
    {
        if (Item != Item_Item.none)
        {
            Inventory_Selector.instance.SelectItem(Item);
        }
    }
}