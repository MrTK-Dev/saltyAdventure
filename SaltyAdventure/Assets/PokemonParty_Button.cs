using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonParty_Button : MonoBehaviour
{
    public GameObject Icon;
    public Text Name;

    BasePokemon ActivePokemon;

    public void ResetUI()
    {
        Icon.GetComponentInParent<GameObject>().SetActive(false);

        Name.text = "";
    }

    public void AddtoUI(BasePokemon Pokemon)
    {
        ActivePokemon = Pokemon;

        Icon.SetActive(true);
        Icon.GetComponentInChildren<Image>().sprite = SpriteSheetLoader.GetSprite(ActivePokemon.Monster);

        Name.text = ActivePokemon.Name;
    }
}
