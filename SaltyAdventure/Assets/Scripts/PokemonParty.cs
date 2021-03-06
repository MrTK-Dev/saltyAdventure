﻿using System.Collections;
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

            //Logger.Debug(GetType(), PList[i].Name);
        }
    }

    public void SelectPartyMember(int Index)
    {
        BasePokemon SelectedPokemon = PList[Index];

        InfoText.text =
            "Name: " + SelectedPokemon.Name + "\n" +
            "Monster: " + SelectedPokemon.Monster + "\n" +
            "Ability: " + SelectedPokemon.Ability + "\n" +
            "Happiness: " + SelectedPokemon.Happiness + "\n" +
            "Shiny: " + SelectedPokemon.isShiny + "\n" +
            "Gender: " + SelectedPokemon.Gender + "\n" +
            "Nature: " + SelectedPokemon.Nature + "\n" +
            "Experience: " + SelectedPokemon.Experience + "\n" +
            "Level: " + SelectedPokemon.Level + "\n" +

            "DVs: " + SelectedPokemon.DValues.HP + ", "
            + SelectedPokemon.DValues.Attack + ", "
            + SelectedPokemon.DValues.Defense + ", "
            + SelectedPokemon.DValues.SpecialAttack + ", "
            + SelectedPokemon.DValues.SpecialDefense + ", "
            + SelectedPokemon.DValues.Speed + "\n" +

            "EVs: " + SelectedPokemon.EValues.HP + ", "
            + SelectedPokemon.EValues.Attack + ", "
            + SelectedPokemon.EValues.Defense + ", "
            + SelectedPokemon.EValues.SpecialAttack + ", "
            + SelectedPokemon.EValues.SpecialDefense + ", "
            + SelectedPokemon.EValues.Speed + "\n" +

            "Stats: " + SelectedPokemon.Stats.HP + ", "
            + SelectedPokemon.Stats.Attack + ", "
            + SelectedPokemon.Stats.Defense + ", "
            + SelectedPokemon.Stats.SpecialAttack + ", "
            + SelectedPokemon.Stats.SpecialDefense + ", "
            + SelectedPokemon.Stats.Speed + "\n" +

            "Moves: " + Moves(SelectedPokemon)
            ;
    }

    string Moves(BasePokemon SelectedPokemon)
    {
        string newString = MoveData.GetData(SelectedPokemon.Moves[0].Move).Name;

        for (int i = 1; i < SelectedPokemon.Moves.Length; i++)
        {
            if (SelectedPokemon.Moves[i] != null)
                newString += ", " + MoveData.GetData(SelectedPokemon.Moves[i].Move).Name;
        }

        return newString;
    }
}