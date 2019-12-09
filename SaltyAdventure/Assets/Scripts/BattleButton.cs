using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleButton : MonoBehaviour
{
    //public GameObject BattleManager;

    public BattleMove Move;

    public void SetUI(BattleMove newMove)
    {
        Move = newMove;
        gameObject.name = "Move_" + transform.GetSiblingIndex() + " [" + newMove.Name + "]";

        GetComponentInChildren<TextMeshProUGUI>().text = newMove.Name;
    }

    public void OnClick()
    {
        if (BattleManager.instance.battleState == BattleManager.BattleState.Selection && Move != null)
            BattleManager.instance.StartRound(Move);
    }
}
