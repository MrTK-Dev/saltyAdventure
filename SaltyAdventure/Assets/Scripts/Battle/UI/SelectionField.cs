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

        Buttons.GetComponent<ButtonParent>().ActivateAll();
    }

    public void AddMovesUI(List<BattleMove> newMoves)
    {
        ActivateUI();

        Buttons.GetComponent<ButtonParent>().UpdateUI(newMoves);
    }

    public void DeActivateUI()
    {
        TextField.text = "";

        Buttons.GetComponent<ButtonParent>().DeActivateAll();
    }

    public void InstantiateSFText(string Text)
    {
        StopAllCoroutines();

        StartCoroutine(TextField.TypeWriterEffect(Text));
    }
}
