﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class Encounter_Manager
{
    static public void Encounter(Place newPlace)
    {
        PlaceData PlaceData = PlaceData.GetData(newPlace);

        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Starting 'Encounter' ...");
        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Place: " + PlaceData.Name);

        PokemonData PokemonData = PokemonData.GetData(GetByRarity(PlaceData));

        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Monster: " + PokemonData.GeneralInformation.Name);

        BasePokemon Pokemon = GetPokemon(PokemonData, PlaceData);

        Pokemon_Party.AddPokemonToParty(Pokemon);
    }

    static BasePokemon GetPokemon(PokemonData PokemonData, PlaceData Place)
    {
        BasePokemon Pokemon = new BasePokemon
        {
            Monster = PokemonData.GeneralInformation.Monster,
            Name = "Olaf"
        };

        return Pokemon;
    }

    static Monster GetByRarity(PlaceData PlaceData)
    {
        float RandomNumber = Random.Range(0f, 100f);
        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "RandomNumber = " + RandomNumber);

        List<int> Chances = new List<int>();

        foreach (Place_MonsterTree Tree in PlaceData.MonsterTree)
        {
            Chances.Add(Tree.Rarity);
        }

        Chances.Sort();

        int choosenRarity = 0;

        for (int i = 0; i < Chances.Count; i++)
        {
            if (Chances[i] >= RandomNumber)
            {
                choosenRarity = Chances[i];

                break;
            }

            choosenRarity = Chances[Chances.Count - 1];
        }

        //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "choosenRarity = " + choosenRarity);

        Monster newMonster = Monster.none;

        for (int i = 0; i < PlaceData.MonsterTree.Length; i++)
        {
            //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "MonsterRarity = " + PlaceData.MonsterTree[i].Rarity);

            if (PlaceData.MonsterTree[i].Rarity == choosenRarity)
            {
                //Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, "Rarity = " + PlaceData.MonsterTree[i].Rarity);

                newMonster = PlaceData.MonsterTree[i].Monster;
            } 
        }

        if (newMonster != Monster.none)
            return newMonster;

        else
        {
            Logger.Error(MethodBase.GetCurrentMethod().DeclaringType, "Could not find a fitting Monster - Please check to Method!");

            return PlaceData.MonsterTree[0].Monster;
        }
    }
}
