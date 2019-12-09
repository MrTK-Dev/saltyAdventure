using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    public RectTransform ToolTip;
    public Transform ButtonParent;

    public bool Selected;   //Selected by Main Button or in Animation

    public void OnButtonHover(GameObject Button)
    {
        if (!Selected && !gameObject.GetComponent<MenuAnimations>().inAnimation)
        {
            if (Button.name == "Continue" || Button.name == "Quit")
            {
                //custom
                ToolTip.gameObject.GetComponent<MenuToolTip>().HoverToolTip(Button);
            }

            else
            {
                if (Button.transform.localPosition.y < -2)
                {
                    //panel up
                    ToolTip.gameObject.GetComponent<MenuToolTip>().SetToolTip(Button, 50f);

                    //SwitchButtons(Button);
                }
                else
                {
                    //panel down
                    ToolTip.gameObject.GetComponent<MenuToolTip>().SetToolTip(Button, -50f);

                    //SwitchButtons(Button);
                }

                //SwitchButtons(Button);
            }

            SwitchButtons(Button);
        }
    }

    public void OnButtonLeave(GameObject Button)
    {
        if (Button.activeSelf && !Selected)
        {
            //disable Panel
            ToolTip.gameObject.GetComponent<MenuToolTip>().ClearToolTip();

            EnableButtons();
        }
    }

    public void SwitchButtons(GameObject Button)
    {
        if (Button.name == "Continue" || Button.name == "Quit")
        {
            for (int i = 0; i < ButtonParent.childCount; i++)
            {
                if (ButtonParent.GetChildren()[i].name != "Continue" && ButtonParent.GetChildren()[i].name != "Quit")
                {
                    ButtonParent.GetChildren()[i].GetComponent<MenuButton>().HideButton();
                }
            }
        }
        else
        {
            for (int i = 0; i < ButtonParent.childCount; i++)
            {
                if (ButtonParent.GetChildren()[i].name != "Continue" && ButtonParent.GetChildren()[i].name != "Quit")
                {
                    if (ButtonParent.GetChildren()[i].transform.localPosition.y != Button.transform.localPosition.y)
                    {
                        ButtonParent.GetChildren()[i].GetComponent<MenuButton>().HideButton();
                    }
                    else if (ButtonParent.GetChildren()[i] != Button)
                    {
                        ButtonParent.GetChildren()[i].GetComponent<MenuButton>().AlphaButton();
                    }
                }
            }
        } 
    }

    public void EnableButtons()
    {
        for (int i = 0; i < ButtonParent.childCount; i++)
        {
            ButtonParent.GetChildren()[i].GetComponent<MenuButton>().ResetButton();
        }
    }
}
