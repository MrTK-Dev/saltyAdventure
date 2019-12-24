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
    public Image SliderFill;
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

        SetSlider();

        Name.text = ActivePokemon.Name;
        Level.text = "Lv." + ActivePokemon.Level;
        HPText.text = ActivePokemon.LiveStats.HP + "/" + ActivePokemon.Stats.HP;

        if (ActivePokemon.Gender != Gender.None)
        {
            IconGender.SetActive(true);

            IconGender.GetComponentInChildren<Image>().sprite = SpriteSheetLoader.LoadSheet("GenderSheet/" + ActivePokemon.Gender.ToString().ToLower());
        }
    }

    void SetSlider()
    {
        HPSlider.SetActive(true);
        HPSlider.GetComponent<Slider>().maxValue = ActivePokemon.Stats.HP;
        HPSlider.GetComponent<Slider>().value = ActivePokemon.LiveStats.HP;

        float newValue = ActivePokemon.LiveStats.HP / (float)ActivePokemon.Stats.HP;
        //Logger.Debug(GetType(), "Value = " + newValue);

        if (newValue >= 1f / 2f)
            SliderFill.color = Color.green;
            
        else if (newValue >= 1f / 5f)
            SliderFill.color = Color.yellow;
            
        else
            SliderFill.color = Color.red;
    }

    public void OnClick()
    {
        PartyController.GetComponent<PokemonParty>().SelectPartyMember(transform.GetSiblingIndex());
    }
}
