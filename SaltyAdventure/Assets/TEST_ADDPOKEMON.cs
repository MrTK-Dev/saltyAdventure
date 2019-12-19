using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ADDPOKEMON : MonoBehaviour
{
    public void Add()
    {
        Debug.Log(Pokemon_Party.GetCount());

        Spawn();
        Party();

        Debug.Log(Pokemon_Party.GetCount());

        Debug.Log(PokemonData.GetData(Pokemon_Party.GetPokemonData(0, false).Monster).Pokedex_Entry.Description);
    }

    void Spawn()
    {
        BasePokemon Pokemon = gameObject.AddComponent<BasePokemon>();

        Pokemon.Monster = Monster.bulbasaur;
        Pokemon.Name = "lelelo";
    }

    void Party()
    {
        Pokemon_Party.AddPokemonToParty(GetComponent<BasePokemon>());
    }
}
