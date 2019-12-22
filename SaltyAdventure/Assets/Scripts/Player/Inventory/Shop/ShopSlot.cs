using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Text Name;
    public Text Price;
    public Image Icon;

    Item_Item Item;

    public void AddItem(ItemData ItemData)
    {
        Item = ItemData.Item;

        Name.text = ItemData.Name;
        Price.text = ItemData.Price.ToString() + "$";
        //Icon.sprite = ItemData.Icon;
    }

    public void OnButtonClick()
    {
        //ShopController.instance.ChooseItem(Item);

        Shop_UI.instance.OnClickSelection(Item);
    }
}
