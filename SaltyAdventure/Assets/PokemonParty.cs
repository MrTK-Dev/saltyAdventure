using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonParty : MonoBehaviour
{
    public GameObject ButtonPartent;

    public List<BasePokemon> List;

    public void UpdateUI()
    {
        for (int i = 0; i < Pokemon_Party.GetCount(); i++)
        {
            List = Pokemon_Party.GetPokemonList();
        }

        for (int i = 0; i < List.Count; i++)
        {
            ButtonPartent.transform.GetChildren()[i].GetComponentInChildren<Text>().text = List[i].Name;
        }
    }
}
