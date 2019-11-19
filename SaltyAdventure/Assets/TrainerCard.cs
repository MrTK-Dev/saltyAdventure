using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainerCard : MonoBehaviour
{
    public GameObject UI;

    public Text PersonalInfo;
    public Text Money;

    public int TrainerID;
    public string TrainerName;

    public int PokeDollar = 1000;
    public int Coins;

    private void Start()
    {
        //change with game start
        PersonalInfo.text = "Henri" + "\n" + "420666";
    }

    private void Update()
    {
        //UpdateUI
        UpdateUI();
    }

    void UpdateUI()
    {
        Money.text = PokeDollar + "$\n" + Coins;
    }

    public void BackButton()
    {
        UI.SetActive(false);
    }
}
