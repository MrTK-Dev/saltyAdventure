using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_ADDPOKEMON : MonoBehaviour
{
    BasePokemon Pokemon;

    public void Add()
    {
        Spawn();
        Party();
        Spawn2();
        Party();
    }

    void Spawn()
    {
        Pokemon = new BasePokemon
        {
            Monster = Monster.bulbasaur,
            Name = PokemonData.GetData(Monster.bulbasaur).GeneralInformation.Name
        };
    }

    void Spawn2()
    {
        Pokemon = new BasePokemon
        {
            Monster = Monster.ivysaur,
            Name = PokemonData.GetData(Monster.ivysaur).GeneralInformation.Name
        };
    }

    void Party()
    {
        Pokemon_Party.AddPokemonToParty(Pokemon);

        //meObject.FindGameObjectWithTag("PokemonParty").GetComponent<PokemonParty>().MList.Add(GetComponent<BasePokemon>().Monster);
    }
}
