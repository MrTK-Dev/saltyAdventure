using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrass : MonoBehaviour
{
    //Base Chance is in %
    public int BaseChance = 50;
    int RandomFL;
    int ActualChance;
    //private readonly Place Place = Place.Route1;

    public void EnemySpawnEvent() {
        ActualChance = 100 / BaseChance;
        RandomFL = Random.Range(0, ActualChance);

        if (RandomFL == 0) {
            //call Battle Scene
            Logger.Info(GetType(), "An wild Enemy appears!");
            Logger.Debug(GetType(), "An wild Enemy appears!");
            Logger.Warning(GetType(), "An wild Enemy appears!");
            Logger.Error(GetType(), "An wild Enemy appears!");
            Logger.Exception(GetType(), "An wild Enemy appears!");
            

            //Debug.Log(PlaceData.GetData(Place).Name);

        } else {
            //nothing happens
            //Debug.Log(RandomFL);
        }
    }
}
