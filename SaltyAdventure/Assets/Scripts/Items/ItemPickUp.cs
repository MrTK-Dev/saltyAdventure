using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item_Item Item;

    public GameObject TextFieldController;
    string TextToAdd;

    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log(Item.ToString());

        bool wasPickedUp = Inventory.AddItem(Item);

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
            TextToAdd = "Player picked up " + Item.ToString();
        } else
        {
            TextToAdd = "Not enough Space in the Inventory";
        }

        //set state
        PlayerStateManager.instance.setState(PlayerStateManager.PlayerState.Interacting);
        //new Textfield
        TextFieldController.GetComponent<TextField>().TriggerTextfield(new string[] {TextToAdd});

    }
}
