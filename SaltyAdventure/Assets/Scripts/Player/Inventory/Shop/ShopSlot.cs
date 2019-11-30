using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{
    public Text Name;
    public Text Price;
    public Image Icon;

    Item newItem;

    public void AddItem(Item item)
    {
        newItem = item;

        Name.text = item.name;
        Price.text = item.Price.ToString() + "$";
        Icon.sprite = item.icon;
    }

    public void OnButtonClick()
    {
        ShopController.instance.ChooseItem(newItem);
    }
}
