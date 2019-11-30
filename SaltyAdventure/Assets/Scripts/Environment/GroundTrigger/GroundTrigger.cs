using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundTrigger : MonoBehaviour
{
    #region Singleton

    public static GroundTrigger instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Tilemap Grass;
    
    public void GrassTrigger()
    {
        //Debug.Log("LOL there is grass");
        Grass.GetComponent<TriggerGrass>().EnemySpawnEvent();
    }
}
