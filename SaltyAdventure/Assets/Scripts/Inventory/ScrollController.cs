using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{
    public GameObject Scrollbar;
    public GameObject Handle;
    public GameObject Content;

    Scrollbar SBScript;
    Image SBImage;

    Image HandleImg;

    RectTransform ContentRect;
    int BaseHeight = 300;

    private void Start()
    {
        SBScript = Scrollbar.GetComponent<Scrollbar>();
        SBImage = Scrollbar.GetComponent<Image>();
        HandleImg = Handle.GetComponent<Image>();
        ContentRect = Content.GetComponent<RectTransform>();

        InventoryManager.instance.OnBagSwitchedCallBack += ControllScrollbar;
        InventoryManager.instance.onItemChangedCallback += ControllScrollbar;
    }

    void ControllScrollbar()
    {
        if (InventoryManager.activeItemList.Count > 4)
        {
            SBScript.interactable = true;
            HandleImg.enabled = true;

            ContentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, BaseHeight + 72 * (InventoryManager.activeItemList.Count - 4));
        } else
        {
            SBScript.interactable = false;
            HandleImg.enabled = false;
            ContentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, BaseHeight);
        }
    }
}
