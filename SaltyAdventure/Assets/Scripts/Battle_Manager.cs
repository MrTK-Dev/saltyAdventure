using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle_Manager : MonoBehaviour
{
    #region References

    public BattleReferences UI = new BattleReferences();

    #endregion

    #region Variables

    //public bool isTrainerBattle = false;

    public List<BasePokemon> PlayerPartyList = new List<BasePokemon>();
    public List<BasePokemon> EnemyPartyList = new List<BasePokemon>();

    public BattleState battleState = BattleState.none;

    public BasePokemon ActivePokemon_P = null;
    public BasePokemon ActivePokemon_E = null;

    #endregion

    #region Methods

    public void StartBattle(BasePokemon[] PlayerParty, BasePokemon[] EnemyParty)
    {
        battleState = BattleState.Starting;

        //set parties
        PlayerPartyList = SetParties(PlayerParty, "Player");
        EnemyPartyList = SetParties(EnemyParty, "Enemy");

        //set active pokemon
        ActivePokemon_P = PlayerPartyList[0];
        ActivePokemon_E = EnemyPartyList[0];

        //UI
        UI.PlayerUnit.GetComponent<Battle_Unit>().SetUI(ActivePokemon_P);
        UI.EnemyUnit.GetComponent<Battle_Unit>().SetUI(ActivePokemon_E);

        StartCoroutine(BattleScene_Start());
    }

    IEnumerator BattleScene_Start()
    {
        battleState = BattleState.Animation;

        UI.Logger.text = "Choose your Move!";

        yield return new WaitForSeconds(1f);

        EnableMoveUI();

        battleState = BattleState.Choice;

        yield return new WaitForSeconds(1f);
    }

    public void PlayerChoice(Move PlayerMove)
    {
        StartCoroutine(BattleScene_Choice(PlayerMove));
    }

    IEnumerator BattleScene_Choice(Move PlayerMove)
    {
        DisableMoveUI();

        Logger.Debug(GetType(), "Player choose: '" + PlayerMove + "'");

        UI.Logger.text = "Player choose: '" + PlayerMove + "'";

        battleState = BattleState.Animation;

        yield return new WaitForSeconds(1f);

        StartCoroutine(BattleScene_Attacks(PlayerMove));
    }

    IEnumerator BattleScene_Attacks(Move PlayerMove)
    {
        if (ActivePokemon_P.LiveStats.Speed > ActivePokemon_E.LiveStats.Speed)
        {

            yield return new WaitForSeconds(5f);

        }

        else
        {

            yield return new WaitForSeconds(5f);

        }

        yield return new WaitForSeconds(1f);
    }

    #endregion

    #region UI Methods

    void EnableMoveUI()
    {
        for (int i = 0; i < 4; i++)
        {
            UI.MoveButtons.transform.GetChildren()[i].GetComponent<Button_Move_Battle>().SetActiveMove(ActivePokemon_P.Moves[i]);
        }
    }

    void DisableMoveUI()
    {
        for (int i = 0; i < 4; i++)
        {
            UI.MoveButtons.transform.GetChildren()[i].GetComponent<Button_Move_Battle>().ResetUI();
        }
    }

    public void EnableMoveDescription(BaseMove newMove)
    {
        if (newMove != null)
            UI.MoveDescription.GetComponent<Battle_MoveDescription>().OpenDescription(newMove);
    }

    public void DisableMoveDescription()
    {
        UI.MoveDescription.GetComponent<Battle_MoveDescription>().ResetDescription();
    }

    #endregion

    #region Variable Methods

    List<BasePokemon> SetParties(BasePokemon[] Party, string Trainer)
    {
        List<BasePokemon> newList = new List<BasePokemon>();

        for (int i = 0; i < Party.Length; i++)
        {
            if (Party[i] != null)
                newList.Add(Party[i]);
        }

        if (newList.Count == 0)
        {
            Logger.Exception(GetType(), "'" + Trainer + "' does not have a valid Pokemon in his Party!");

            return null;
        }

        else
            return newList;
    }

    #endregion
}

#region Enums + SubClasses

public enum BattleState
{
    none,
    Starting,
    Choice,
    Animation,
    Ending
}

public enum BattleResult
{
    Undecided,
    PlayerWin,
    EnemyWin,
    Escaped,
    Caught
}

[System.Serializable]
public class BattleReferences
{
    public GameObject PlayerUnit,
        EnemyUnit,
        MoveButtons,
        MoveDescription;
    public Text Logger;
}

#endregion