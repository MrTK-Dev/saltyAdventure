using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Unit : MonoBehaviour
{
    public Text Name;
    public Text Level;
    public Text HP;
    public GameObject Slider;
    public GameObject IconGender;
    public GameObject BattleGround;

    public void SetUI(BasePokemon Pokemon)
    {
        Name.text = Pokemon.Name;
        Level.text = "Lv." + Pokemon.Level;
        HP.text = Pokemon.LiveStats.HP + "/" + Pokemon.Stats.HP;

        Slider.GetComponent<Slider>().maxValue = Pokemon.Stats.HP;
        Slider.GetComponent<Slider>().value = Pokemon.LiveStats.HP;

        if (Pokemon.Gender != Gender.None)
        {
            IconGender.SetActive(true);

            IconGender.GetComponentInChildren<Image>().sprite = SpriteSheetLoader.LoadSheet("GenderSheet/" + Pokemon.Gender.ToString().ToLower());
        }

        BattleGround.SetActive(true);
        BattleGround.name = Pokemon.Name;
        BattleGround.GetComponent<Image>().sprite = SpriteSheetLoader.GetSprite(Pokemon.Monster, Pokemon.isShiny);
    }

    public void ResetUI()
    {
        Name.text = "Empty";
        Level.text = "Lv.";
        HP.text = "0/0";

        Slider.GetComponent<Slider>().maxValue = 1;
        Slider.GetComponent<Slider>().value = 1;

        BattleGround.SetActive(false);
        BattleGround.name = "Ground_" + BattleGround.transform.GetSiblingIndex();
    }
}
