using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TTContinue : MonoBehaviour
{
    public Text Categories;
    public Text PlayerInfo;

    public IEnumerator Activate(GameObject Button)
    {
        //Categories
        string Continue =
            "Player: " + "\n" +
            "Place: " + "\n" +
            "Playtime: " + "\n" +
            "Pokedex: ";

        //StartCoroutine(Categories.TypeWriterEffect(Continue, 0.075f));
        Categories.text = Continue;

        yield return new WaitForSeconds(0.1f);


        //Data
        string Continue2 = 
            LoadPlayerData.Read("PlayerData").Name + "\n" +
            LoadPlayerData.Read("PlayerData").Place + "\n" +
            LoadPlayerData.Read("PlayerData").Playtime.TimeFormat("dhm") + "\n" +
            LoadPlayerData.Read("PlayerData").PokedexCount;

        StartCoroutine(PlayerInfo.TypeWriterEffect(Continue2, 0.1f));

        yield return new WaitForSeconds(1.5f);
    }

    public void DeActivate()
    {
        StopAllCoroutines();

        Categories.text = "";
        PlayerInfo.text = "";
    }
}
