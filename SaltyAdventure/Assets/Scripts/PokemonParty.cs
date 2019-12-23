using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonParty : MonoBehaviour
{
    public GameObject ButtonPartent;

    public List<BasePokemon> PList;

    public void UpdateUI()
    {
        PList = Pokemon_Party.GetPokemonList();

        for (int i = 0; i < PList.Count; i++)
        {
            ButtonPartent.transform.GetChildren()[i].GetComponentInChildren<PokemonParty_Button>().AddtoUI(PList[i]);

            Logger.Debug(GetType(), PList[i].Name);
        }
    }
}