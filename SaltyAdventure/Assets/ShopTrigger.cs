using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTrigger : Interactable
{
    public Shop shop;
    public GameObject ShopController;

    public override void Interact()
    {
        base.Interact();

        TriggerShop();
    }

    void TriggerShop()
    {
        ShopController.GetComponent<ShopController>().OpenShopUI(shop);
    }
}
