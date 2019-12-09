using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimations : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject CreditsPage;
    public GameObject ConnectPage;

    public bool inAnimation;

    public void OnClick(string Direction)
    {
        Debug.Log("Click");

        //Transition
        StartCoroutine(Transition(Direction));
    }

    IEnumerator Transition(string Direction)
    {
        inAnimation = true;

        if (Direction == "left")
        {
            CreditsPage.SetActive(true);

            for (int i = 0; i < 960 / 20; i++)
            {
                MainMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(i + 1) * 20, 0);
                CreditsPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(960 - (i + 1) * 20, 0);
                ConnectPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-960 - (i + 1) * 20, 0);

                yield return new WaitForSeconds(0);
            }

            MainMenu.SetActive(false);
        }
        else if (Direction == "right")
        {
            ConnectPage.SetActive(true);
            
            for (int i = 0; i < 960 / 20; i++)
            {
                MainMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2((i + 1) * 20, 0);
                CreditsPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(960 + (i + 1) * 20, 0);
                ConnectPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-960 + (i + 1) * 20, 0);

                yield return new WaitForSeconds(0);
            }

            MainMenu.SetActive(false);
        }
        else if (Direction == "Mright")
        {
            MainMenu.SetActive(true);

            for (int i = 0; i < 960 / 20; i++)
            {
                MainMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(-960 + (i + 1) * 20, 0);
                CreditsPage.GetComponent<RectTransform>().anchoredPosition = new Vector2((i + 1) * 20, 0);
                ConnectPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1920 + (i + 1) * 20, 0);

                yield return new WaitForSeconds(0);
            }

            CreditsPage.SetActive(false);
        }
        else if (Direction == "Mleft")
        {
            MainMenu.SetActive(true);

            for (int i = 0; i < 960 / 20; i++)
            {
                MainMenu.GetComponent<RectTransform>().anchoredPosition = new Vector2(960 - (i + 1) * 20, 0);
                CreditsPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(1920 - (i + 1) * 20, 0);
                ConnectPage.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(i + 1) * 20, 0);

                yield return new WaitForSeconds(0);
            }

            ConnectPage.SetActive(false);
        }

        inAnimation = false;
    }
}
