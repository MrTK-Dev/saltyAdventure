using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFieldController : MonoBehaviour
{
    public GameObject TF_UI;
    public GameObject TF_Text;
    public GameObject TF_Forward;

    public bool isTextField = false;
    bool lookForKey = false;

    private void Update()
    {
        if (lookForKey)
        {
            AddForward();

            if (Input.GetButtonDown("Interact"))
            {
                ForwardText();
            }
        }
    }

    public void InitializeTextField()
    {
        isTextField = true;
        TF_UI.SetActive(true);
        TF_Text.GetComponent<Text>().text = "";
    }

    void DisableTextField()
    {
        isTextField = false;
        TF_UI.SetActive(false);
        TF_Text.GetComponent<Text>().text = "";
    }

    public void InitializeText(char TextContent)
    {
        TF_Text.GetComponent<Text>().text += TextContent;
    }

    //only for testing
    public void AddText(string TextContent)
    {
        InitializeTextField();
        TF_Text.GetComponent<Text>().text = TextContent;
        lookForKey = true;
    }

    //TODO
    //add support for multi-liners
    void ForwardText()
    {
        TF_Forward.GetComponent<Text>().text = "";

        DisableTextField();
        
        PlayerStateManager.instance.setState(PlayerStateManager.PlayerState.Idle);
        
        lookForKey = false;
        isTextField = false;
    }

    void AddForward()
    {
        //TODO
        //retrieve button.name
        TF_Forward.GetComponent<Text>().text = "Press " + "Space" + " to continue";
    }
}