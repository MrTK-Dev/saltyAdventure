using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagSwitchHandler : MonoBehaviour
{
    public Transform BagParent;
    public GameObject ScrollInv;

    List<GameObject> BagList;

    void Start()
    {
        BagList = BagParent.FindObjectsWithTag("Bag");
        ScrollInv.GetComponent<InvScroll>().SetActiveBagList(BagList[0]);
    }

    public void SwitchBag(GameObject activeBag)
    {
        //Trigger Scroll Inv Update
        ScrollInv.GetComponent<InvScroll>().SetActiveBagList(activeBag);

        //switch Item Highlight
        ItemHighlight.instance.UpdateAfterBagSwitch(activeBag);
    }
}