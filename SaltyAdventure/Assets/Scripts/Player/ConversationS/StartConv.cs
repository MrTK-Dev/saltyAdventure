using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;

public class StartConv : Interactable
{
    public GameObject TextFieldController;
    public Conversation Conv;

    public override void Interact()
    {
        base.Interact();

        StartConversation();
    }

    void StartConversation()
    {
        TextFieldController.GetComponent<TextField>().TriggerTextfield(Conv.ConversationText);
    }
}