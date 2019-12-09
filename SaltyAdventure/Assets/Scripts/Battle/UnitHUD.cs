using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHUD : MonoBehaviour
{
    public Text Name;
    public Text Level;
    public Text HP;
    public GameObject Slider; 

    public Pokemon PKMN;

    public List<BattleMove> Moves;

    public void ResetHP()
    {
        PKMN.currentHP = PKMN.maxHP;
    }
}
