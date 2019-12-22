using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : Interactable
{
    public Shop_Shop Shop;
    public GameObject ShopController;

    public override void Interact()
    {
        base.Interact();

        TriggerShop();
    }

    void TriggerShop()
    {
        ShopController.GetComponent<Shop_UI>().OpenShopUI(Shop);
    }
}
