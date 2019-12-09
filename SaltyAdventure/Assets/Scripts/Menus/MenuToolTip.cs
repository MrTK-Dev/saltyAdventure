using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuToolTip : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject TTContinue;
    public GameObject TTQuit;

    public Text Description;

    public void SetToolTip(GameObject Button, float YValue)
    {
        SetHeightOfTransform(100f);

        transform.localPosition = new Vector2(0, YValue);

        gameObject.GetComponent<Image>().enabled = true;

        //Name.text = Button.GetComponent<MenuButton>().Name;

        //typewriter effect
        StartCoroutine(Description.TypeWriterEffect(Button.GetComponent<MenuButton>().Description));
    }

    public void ClearToolTip()
    {
        StopAllCoroutines();

        //Name.text = "";
        Description.text = "";

        gameObject.GetComponent<Image>().enabled = false;

        TTContinue.GetComponent<TTContinue>().DeActivate();
    }

    public void ShowContinue(GameObject Button)
    {
        StopAllCoroutines();

        StartCoroutine(TTContinue.GetComponent<TTContinue>().Activate(Button));
    }

    public void ShowQuit(GameObject Button)
    {
        StopAllCoroutines();
    }

    public void HoverToolTip(GameObject Button)
    {
        ToggleToolTip(Button);

        StartCoroutine(Description.TypeWriterEffect(Button.GetComponent<MenuButton>().Description));
    }

    public void ToggleToolTip(GameObject Button)
    {
        SetHeightOfTransform(200f);

        transform.localPosition = new Vector2(0, 0);

        gameObject.GetComponent<Image>().enabled = true;
    }

    void SetHeightOfTransform(float Height)
    {
        gameObject.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Height);
    }
}
