using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System;

public class StartConv : MonoBehaviour
{
    public GameObject TextFieldController;

    //public float delayBetweenChars = 0.125f;
    //public float delayAfterPunctuation = 0.5f;
    /*
    private float originDelayBetweenChars = 0.0f;
    private bool lastCharPunctuation = false;
    private char charComma = ",".ToCharArray()[0];
    private char charPeriod = ".".ToCharArray()[0];

    public string[] TextContent;*/
    /*
    public void StartConversation()
    {
        //activate UI
        TextFieldController.GetComponent<TextFieldController>().InitializeTextField();

        //Print
        PrintText();
    }

    public void PrintText()
    {
        for (int i = 0; i < TextContent.Length; i++)
        {
            Invoke("Start_PlayText", delayBetweenChars); //Invoke effect

            void Start_PlayText()
            {
                StartCoroutine(PlayText());
            }
        }
    }



    IEnumerator PlayText()
    {

        foreach (char c in TextContent)
        {
            delayBetweenChars = originDelayBetweenChars;

            if (lastCharPunctuation)  //If previous character was a comma/period, pause typing
            {
                yield return new WaitForSeconds(delayBetweenChars = delayAfterPunctuation);
                lastCharPunctuation = false;
            }

            if (c == charComma || c == charPeriod)
            {
                lastCharPunctuation = true;
            }

            //Function in TFC
            TextFieldController.GetComponent<TextFieldController>().InitializeText(c);
            yield return new WaitForSeconds(delayBetweenChars);
        }
    }*/
}