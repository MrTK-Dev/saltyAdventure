using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ADDPOKEMON : MonoBehaviour
{
    public void Add()
    {
        Spawn();
        Party();
    }

    void Spawn()
    {
        BasePokemon Pokemon = GetComponent<BasePokemon>();

        Pokemon.Monster = Monster.bulbasaur;
        Pokemon.Name = PokemonData.GetData(Monster.bulbasaur).GeneralInformation.Name;
    }

    void Party()
    {
        Pokemon_Party.AddPokemonToParty(GetComponent<BasePokemon>());
    }
}
