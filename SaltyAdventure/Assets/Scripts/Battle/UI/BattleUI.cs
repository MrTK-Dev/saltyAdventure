using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    /*public GameObject BattleManager;

    public GameObject PlayerHUD;
    public GameObject EnemyHUD;
    public GameObject SelectionField;

    public void InstantiateUI()
    {
        //Player
        InstantiateUnit(PlayerHUD);
        InstantiateUnit(EnemyHUD);
    }

    void InstantiateUnit(GameObject Unit)
    {
        //Name
        Unit.GetComponent<UnitHUD>().Name.text = Unit.GetComponent<UnitHUD>().PKMN.Name;
        //Level
        Unit.GetComponent<UnitHUD>().Level.text = "Lvl " + Unit.GetComponent<UnitHUD>().PKMN.Level.ToString();
        //HP
        Unit.GetComponent<UnitHUD>().HP.text = Unit.GetComponent<UnitHUD>().PKMN.currentHP.ToString() + "/" + Unit.GetComponent<UnitHUD>().PKMN.maxHP.ToString();
        //Slider
        Unit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().UpdateSlider(Unit.GetComponent<UnitHUD>().PKMN.maxHP, Unit.GetComponent<UnitHUD>().PKMN.currentHP);
    }

    public void InstantiateUIHP()
    {
        //Player
        InstantiateUnitHP(PlayerHUD);
        InstantiateUnitHP(EnemyHUD);
    }

    void InstantiateUnitHP(GameObject Unit)
    {
        Unit.GetComponent<UnitHUD>().HP.text = Unit.GetComponent<UnitHUD>().PKMN.currentHP.ToString() + "/" + Unit.GetComponent<UnitHUD>().PKMN.maxHP.ToString();
    }

    public void SetActiveUnit(string Unit)
    {
        if (Unit == "player")
        {
            BattleManager.GetComponent<BattleManager>().activeUnit = PlayerHUD;
            BattleManager.GetComponent<BattleManager>().passiveUnit = EnemyHUD;
        }
        else
        {
            BattleManager.GetComponent<BattleManager>().passiveUnit = PlayerHUD;
            BattleManager.GetComponent<BattleManager>().activeUnit = EnemyHUD;
        }
    }

    public void SwitchActiveUnit()
    {
        if (BattleManager.GetComponent<BattleManager>().activeUnit == PlayerHUD)
        {
            BattleManager.GetComponent<BattleManager>().passiveUnit = PlayerHUD;
            BattleManager.GetComponent<BattleManager>().activeUnit = EnemyHUD;
        }
        else
        {
            BattleManager.GetComponent<BattleManager>().activeUnit = PlayerHUD;
            BattleManager.GetComponent<BattleManager>().passiveUnit = EnemyHUD;
        }
    }
    */








    public GameObject SelectionField;
    public GameObject PlayerHUD;
    public GameObject EnemyHUD;

    public void InstantiateUI()
    {
        //Player
        InstantiateUnit(PlayerHUD);
        InstantiateUnit(EnemyHUD);
    }

    void InstantiateUnit(GameObject Unit)
    {
        UnitHUD HUD = Unit.GetComponent<UnitHUD>();
        BasePokemon Pokemon = Unit.GetComponent<BasePokemon>();

        //Name
        HUD.Name.text = Pokemon.Name;

        //Level
        HUD.Level.text = "Lvl " + Pokemon.Level.ToString();

        //HP & Slider
        HUD.HP.text = Pokemon.LiveStats.HP.ToString() + "/" + Pokemon.Stats.HP.ToString();

        HUD.Slider.GetComponent<SliderHP>().UpdateSlider(Pokemon.Stats.HP, Pokemon.LiveStats.HP);
    }

    public void InstantiateSelection()
    {
        //SelectionField.GetComponent<SelectionField>().AddMovesUI(PlayerHUD.GetComponent<UnitHUD>().Moves);
    }
}
