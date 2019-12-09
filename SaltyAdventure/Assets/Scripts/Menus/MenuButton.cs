using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public GameObject BText;

    public string Name;
    public string Description;

    public void HideButton()
    {
        gameObject.GetComponent<Image>().ChangeAlpha2(0);

        BText.SetActive(false);
    }

    public void AlphaButton()
    {
        gameObject.GetComponent<Image>().ChangeAlpha2(50f / 255f);
    }

    public void ResetButton()
    {
        gameObject.GetComponent<Image>().ChangeAlpha2(1f);

        BText.SetActive(true);
    }
}
