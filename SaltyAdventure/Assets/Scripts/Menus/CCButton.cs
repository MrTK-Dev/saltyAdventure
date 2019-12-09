using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CCButton : MonoBehaviour
{
    public GameObject CCredits;
    public GameObject CConnect;

    public void OnEnter(GameObject Button)
    {
        StartCoroutine(Animation(Button));
    }

    IEnumerator Animation(GameObject Button)
    {
        //40 -> 200
        for (int i = 0; i < 160/2; i++)
        {
            Button.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, i * 2 + 40);

            yield return new WaitForSeconds(0);
        }
    }

    public void OnLeave(GameObject Button)
    {
        StopAllCoroutines();

        //ResetButtons
        CCredits.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40);
        CConnect.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 40);
        //StartCoroutine(Animation2(Button));
    }

    IEnumerator Animation2(GameObject Button)
    {
        //200 -> 40
        for (int i = 0; i < 160 / 2; i++)
        {
            Button.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 200 - i * 2);

            yield return new WaitForSeconds(0);
        }
    }
}
