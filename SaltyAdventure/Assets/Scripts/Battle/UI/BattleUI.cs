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
        //Name
        Unit.GetComponent<UnitHUD>().Name.text = Unit.GetComponent<UnitHUD>().PKMN.Name;
        //Level
        Unit.GetComponent<UnitHUD>().Level.text = "Lvl " + Unit.GetComponent<UnitHUD>().PKMN.Level.ToString();
        //HP
        Unit.GetComponent<UnitHUD>().HP.text = Unit.GetComponent<UnitHUD>().PKMN.currentHP.ToString() + "/" + Unit.GetComponent<UnitHUD>().PKMN.maxHP.ToString();
        //Slider
        Unit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().UpdateSlider(Unit.GetComponent<UnitHUD>().PKMN.maxHP, Unit.GetComponent<UnitHUD>().PKMN.currentHP);
    }

    public void InstantiateSelection()
    {
        SelectionField.GetComponent<SelectionField>().AddMovesUI(PlayerHUD.GetComponent<UnitHUD>().Moves);
    }
























































    /*public bool AttackMove(Pokemon UnitDefender, Pokemon UnitAttacker)
    {
        int cachedHP = UnitDefender.currentHP;

        int DMG = Random.Range(0, 20) + 1;

        if (UnitDefender.currentHP - DMG <= 0)
        {
            UnitDefender.currentHP = 0;
        }

        else
        {
            UnitDefender.currentHP -= DMG;
        }

        SliderAnimation(UnitDefender);

        InstantiateUIHP();

        Debug.Log(UnitDefender.Name + " got hurt by " + DMG);

        //InstantiateUI();

        return (UnitDefender.currentHP == 0);
    }

    public void HealMove(Pokemon Unit)
    {
        if (Unit.currentHP + 10 >= Unit.maxHP)
            Unit.currentHP = Unit.maxHP;
        else
            Unit.currentHP += 10;

        Debug.Log("Healed " + Unit.Name);

        InstantiateUI();
    }

    void SliderAnimation(Pokemon Unit)
    {
        if (Unit == PlayerHUD.GetComponent<UnitHUD>().PKMN)
        {
            StartCoroutine(PlayerHUD.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().SliderAnimation(Unit.currentHP));
        }
        else
        {
            StartCoroutine(EnemyHUD.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().SliderAnimation(Unit.currentHP));
        }

        //InstantiateUI();
    }*/





}
