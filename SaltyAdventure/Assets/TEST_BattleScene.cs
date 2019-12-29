using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_BattleScene : MonoBehaviour
{
    public GameObject BattleManager;

    public void OnClick()
    {
        BasePokemon[] newList = new BasePokemon[1];
        newList[0] = Encounter_Manager.GetEncounter(Place.Route1);

        Pokemon_Party.AddPokemonToParty(Encounter_Manager.GetEncounter(Place.Route1));

        //Logger.Debug(GetType(), "'" + Pokemon.Name + "' got choosen.");

        BattleManager.GetComponent<Battle_Manager>().StartBattle(Pokemon_Party.List, newList);
    }
}
