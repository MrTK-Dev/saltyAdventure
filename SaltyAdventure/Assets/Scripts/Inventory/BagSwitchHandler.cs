using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static List<GameObject> FindObjectsWithTag(this Transform parent, string tag)
    {
        List<GameObject> taggedGameObjects = new List<GameObject>();

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == tag)
            {
                taggedGameObjects.Add(child.gameObject);
            }
            if (child.childCount > 0)
            {
                taggedGameObjects.AddRange(FindObjectsWithTag(child, tag));
            }
        }
        return taggedGameObjects;
    }
}

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