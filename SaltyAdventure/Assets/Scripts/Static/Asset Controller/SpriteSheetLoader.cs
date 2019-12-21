using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for Retrieving Sprites from Sheets.
/// </summary>
public static class SpriteSheetLoader
{
    #region Atlas Handling

    class Atlas
    {
        public string Reference;
        public Sprite[] SpriteList;
    }

    static List<Atlas> AtlasList = new List<Atlas>();

    static Atlas AddNewAtlas(string newAtlas)
    {
        for (int i = 0; i < AtlasList.Count; i++)
        {
            if (AtlasList[i].Reference == newAtlas)
                return AtlasList[i];
        }

        Sprite[] newSpriteList = Resources.LoadAll<Sprite>("Sheets/" + newAtlas);

        if (newSpriteList != null && newSpriteList.Length > 0)
        {
            Atlas Atlas = new Atlas()
            {
                Reference = newAtlas,
                SpriteList = newSpriteList
            };

            AtlasList.Add(Atlas);

            return Atlas;
        }

        else
            throw new System.Exception(newAtlas + " does not exist in 'Assets/Resources/Sheets/' ! Check your Path or create a new one.");
    }

    #endregion

    #region Basic Methods

    static public Sprite LoadSheet(string Path)
    {
        //Debug.Log(Path);

        string[] Array = Path.Split("/" [0]);

        Atlas Atlas = AddNewAtlas(Array[0]);

        for (int i = 0; i < Atlas.SpriteList.Length; i++)
        {
            //Debug.Log(Atlas.SpriteList[i].name);

            if (Atlas.SpriteList[i].name == Array[1])
                return Atlas.SpriteList[i];
        }

        Debug.Log(Array[1] + " doesn't exist on " + Array[0]);
        return Atlas.SpriteList[0];
    }

    #endregion

    #region Advanced Methods

    /// <summary>
    /// Returns the Sprite of the given Input.
    /// </summary>
    /// <param name="Monster"></param>
    /// <param name="shiny">Set to 'true' for Shiny Sprite</param>
    /// <returns></returns>
    static public Sprite GetSprite(Monster Monster, bool shiny = false)
    {
        if (!shiny)
            return LoadSheet(JSON_PokemonData.LoadData(Monster).GeneralInformation.Icon);

        else
            return LoadSheet(JSON_PokemonData.LoadData(Monster).GeneralInformation.IconShiny);
    }

    #endregion
}