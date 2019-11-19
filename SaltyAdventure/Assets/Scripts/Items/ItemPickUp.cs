using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public GameObject TextFieldController;
    string TextToAdd;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        bool wasPickedUp = InventoryController.instance.AddItemToInventory(item);

        if (wasPickedUp)
        {
            //Destroy Object
            Destroy(gameObject);
        }
        
        InGameLogger(wasPickedUp);
    }

    void InGameLogger(bool PickedUp)
    {
        if (PickedUp)
        {
            TextToAdd = "Player picked up " + item.name;
        } else
        {
            TextToAdd = "Not enough Space in the Inventory";
        }

        //set state
        PlayerStateManager.instance.setState(PlayerStateManager.PlayerState.Interacting);
        //add Textfield
        TextFieldController.GetComponent<TextFieldController>().AddText(TextToAdd);
    }
}
