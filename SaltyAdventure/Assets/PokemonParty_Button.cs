using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonParty_Button : MonoBehaviour
{
    public GameObject PartyController;

    public GameObject Icon;
    public GameObject IconGender;
    public GameObject HPSlider;
    public Text Name;
    public Text Level;
    public Text HPText;

    BasePokemon ActivePokemon;

    public void ResetUI()
    {
        ActivePokemon = null;

        Icon.GetComponentInParent<GameObject>().SetActive(false);

        Name.text = "";
        Level.text = "";
        HPText.text = "";
    }

    public void AddtoUI(BasePokemon Pokemon)
    {
        ActivePokemon = Pokemon;

        Icon.SetActive(true);
        Icon.GetComponentInChildren<Image>().sprite = SpriteSheetLoader.GetSprite(ActivePokemon.Monster);

        HPSlider.SetActive(true);

        Name.text = ActivePokemon.Name;
        Level.text = "Lv." + ActivePokemon.Level;
        HPText.text = ActivePokemon.LiveStats.HP + "/" + ActivePokemon.Stats.HP;

        if (ActivePokemon.Gender != Gender.None)
        {
            IconGender.SetActive(true);

            IconGender.GetComponentInChildren<Image>().sprite = SpriteSheetLoader.LoadSheet("GenderSheet/" + ActivePokemon.Gender.ToString().ToLower());
        }
    }

    public void OnClick()
    {
        PartyController.GetComponent<PokemonParty>().SelectPartyMember(transform.GetSiblingIndex());
    }
}
