using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public Text textField;
    public Text ItemCount;
    public Item item;
    public Image ButtonBG;

    public int Index;

    public void AddItem (Item newItem) {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;

        removeButton.interactable = true;
        ButtonBG.enabled = true;

        //change textfields
        textField.text = item.name;
        ItemCount.text = "x " + item.StackSize.ToString();

        GetComponentInChildren<Image>().enabled = true;

        //CheckIndex();
    }

    public void ClearSlot () {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        textField.text = null;
        ItemCount.text = null;

        removeButton.interactable = false;
        ButtonBG.enabled = false;
    }

    public void OnRemoveButton()
    {
        InventoryManager.instance.Remove(item);
        //HighlightItem();
    }

    public void HighlightItem()
    {
        if (item != null)
        {
            ItemHighlight.instance.HighlightItem(item);
        }
    }

    void CheckIndex()
    {
        Index = InventoryManager.activeItemList.IndexOf(item);
    }
}

//TODO
//Slider Steps depending on ItemList