using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonParty : MonoBehaviour
{
    public GameObject ButtonPartent;
    public Text InfoText;

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

    public void OnClick(int Index)
    {
        BasePokemon SelectedPokemon = PList[Index];

        InfoText.text =
            "Name: " + SelectedPokemon.Name + "\n" +
            "Monster: " + SelectedPokemon.Monster + "\n" +
            "Nature: " + SelectedPokemon.Nature + "\n" +
            "Level: " + SelectedPokemon.Level + "\n" +

            "DVs: " + SelectedPokemon.DValues.HP + ", "
            + SelectedPokemon.DValues.Attack + ", "
            + SelectedPokemon.DValues.Defence + ", "
            + SelectedPokemon.DValues.SpecialAttack + ", "
            + SelectedPokemon.DValues.SpecialDefence + ", "
            + SelectedPokemon.DValues.Speed + "\n" +

            "EVs: " + SelectedPokemon.EValues.HP + ", "
            + SelectedPokemon.EValues.Attack + ", "
            + SelectedPokemon.EValues.Defence + ", "
            + SelectedPokemon.EValues.SpecialAttack + ", "
            + SelectedPokemon.EValues.SpecialDefence + ", "
            + SelectedPokemon.EValues.Speed + "\n" +

            "Stats: " + SelectedPokemon.Stats.HP + ", "
            + SelectedPokemon.Stats.Attack + ", "
            + SelectedPokemon.Stats.Defence + ", "
            + SelectedPokemon.Stats.SpecialAttack + ", "
            + SelectedPokemon.Stats.SpecialDefence + ", "
            + SelectedPokemon.Stats.Speed
            ;
    }
}