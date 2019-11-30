using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionField : MonoBehaviour
{
    public Text TextField;

    public GameObject Buttons;



    public void ActivateUI()
    {
        InstantiateSFText("Henri hat gepupst" + "\n" + "Waiting for an Input...");

        Buttons.AddComponent<ButtonParent>().ActivateAll();
    }

    public void DeActivateUI()
    {
        TextField.text = "";

        Buttons.AddComponent<ButtonParent>().DeActivateAll();
    }

    public void InstantiateSFText(string Text)
    {
        StartCoroutine(AnimateText());

        IEnumerator AnimateText()
        {
            for (int i = 0; i < (Text.Length + 1); i++)
            {
                TextField.text = Text.Substring(0, i);

                if (Text.Substring(0, i).EndsWithMulti(new string[] { ".", "," }))  //Delay
                {
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    yield return new WaitForSeconds(0.05f);
                }
            }
        }
    }
}
