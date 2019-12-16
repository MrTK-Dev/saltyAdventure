using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DebugScene : MonoBehaviour
{
    public void WriteMoveData()
    {
        /*JSON_MoveData.WriteDataBase();

        MoveDataBase DataBase = JSON_MoveData.LoadDataBase();

        for (int i = 0; i < MoveData.Count; i++)
        {
            Debug.Log(DataBase.MoveData[i].Name);
        }*/

        JSON_PokemonData.WriteDataBase();

        PokemonDataBase DataBase = JSON_PokemonData.LoadDataBase();

        for (int i = 0; i < PokemonData.Count; i++)
        {
            Debug.Log(DataBase.PokemonData[i].GeneralInformation.Name);
        }
    }
}