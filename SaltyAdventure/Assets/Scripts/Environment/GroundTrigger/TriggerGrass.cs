using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrass : MonoBehaviour
{
    //Base Chance is in %
    public int BaseChance = 50;
    int RandomFL;
    int ActualChance;
    private readonly Place Place = Place.Route1;

    public void EnemySpawnEvent() {
        ActualChance = 100 / BaseChance;
        RandomFL = Random.Range(0, ActualChance);

        if (RandomFL == 0)
        {
            Encounter_Manager.Encounter(Place);

        }
        else
        {
            //nothing happens
            //Debug.Log(RandomFL);
        }
    }
}
