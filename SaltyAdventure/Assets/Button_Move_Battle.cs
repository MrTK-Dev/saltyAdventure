using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Move_Battle : MonoBehaviour
{
    Battle_Manager BM;
    public Text Name;

    public Move Move = Move.none;
    BaseMove ActiveMove;
    MoveData MoveData;

    private void Awake()
    {
        if (BM == null)
            BM = GameObject.FindGameObjectWithTag("BattleManager").GetComponent<Battle_Manager>();
    }

    public void SetActiveMove(BaseMove newMove)
    {
        if (newMove != null)
        {
            ActiveMove = newMove;
            Move = ActiveMove.Move;
            MoveData = MoveData.GetData(Move);

            gameObject.name = "MoveButton (" + MoveData.Name + ")";
            Name.text = MoveData.Name;
        }

        else
            ResetUI();
    }

    public void ResetUI()
    {
        gameObject.name = "MoveButton (" + transform.GetSiblingIndex() + ")";
        Name.text = "-------";
        Move = Move.none;
        ActiveMove = null;
    }

    public void OnClick()
    {
        BM.PlayerChoice(Move);
    }

    public void OnEnter()
    {
        if (Move != Move.none)
            BM.EnableMoveDescription(ActiveMove);
    }

    public void OnExit()
    {
        BM.DisableMoveDescription();
    }
}
