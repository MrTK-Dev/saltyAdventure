using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public GameObject BattleStationController;
    public GameObject BattleUI;

    Pokemon Player;
    Pokemon Enemy;

    public GameObject activeUnit;
    public GameObject passiveUnit;

    public BattleState battleState;

    public enum BattleState
    {
        Idle,
        Selection,


        PlayerTurn,
        EnemyTurn,

        BattleWon,
        BattleLost
    }

    //public Slider PlayerSlider;
    //public Image FillPlayer;

    private void Start()
    {
        battleState = BattleState.Idle;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            //MakeDmg();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartBattle();
        }
    }

    public void StartBattle()
    {
        //set Units
        Player = BattleUI.GetComponent<BattleUI>().PlayerHUD.GetComponent<UnitHUD>().PKMN;
        Enemy = BattleUI.GetComponent<BattleUI>().EnemyHUD.GetComponent<UnitHUD>().PKMN;

        //reset HP  //test
        Player.currentHP = Player.maxHP;
        Enemy.currentHP = Enemy.maxHP;

        //Setup Battle
        SetUpBattle();
    }

    ///<summary>
    ///Starts the Battle
    ///</summary>
    void SetUpBattle()
    {
        //enable Battle UI
        BattleUI.GetComponent<BattleUI>().InstantiateUI();
        //activate SelectionField
        BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().ActivateUI();

        StartSelection();

        //StartCoroutine(BattleLoop());
    }



    void StartSelection()
    {
        battleState = BattleState.Selection;

        BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().ActivateUI();
    }

    IEnumerator StartIdle(string AttackType)
    {
        BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().DeActivateUI();

        battleState = BattleState.Idle;

        if (Player.Speed > Enemy.Speed)
        {
            PlayerMove();

            yield return new WaitForSeconds(2f);

            EnemyMove();
        }
        else
        {
            EnemyMove();

            yield return new WaitForSeconds(2f);

            PlayerMove();
        }

        void PlayerMove()
        {
            if (AttackType == "Attack")
            {
                StartCoroutine(Attack(Player, Enemy));
            }
            else if (AttackType == "Heal")
            {
                StartCoroutine(Heal(Player, Enemy));
            }
        }

        yield return new WaitForSeconds(2f);

        StartSelection();
    }

    public void OnButtonAttack()
    {
        if (battleState == BattleState.Selection)
        {
            Debug.Log("Player chose attack");

            //StartCoroutine(Attack(Player, Enemy));
            StartCoroutine(StartIdle("Attack"));
        }
    }

    public void OnButtonHeal()
    {
        if (battleState == BattleState.Selection)
        {
            Debug.Log("Player chose heal");

            //StartCoroutine(Heal(Player, Enemy));
            StartCoroutine(StartIdle("Heal"));
        }
    }

    void EnemyMove()
    {
        if (Random.Range(0, 2) == 0)
        {
            StartCoroutine(Attack(Enemy, Player));

            Debug.Log("Enemy chose attack");
        }
        else
        {
            StartCoroutine(Heal(Enemy, Player));
            Debug.Log("Enemy chose attack");
        }
    }


























    /*


    IEnumerator BattleLoop()
    {
        yield return new WaitForSeconds(0.1f);

        //check for Speed
        if (Player.Speed > Enemy.Speed)
        {
            BattleUI.GetComponent<BattleUI>().SetActiveUnit("player");

            battleState = BattleState.Selection;
        }

        else
        {
            BattleUI.GetComponent<BattleUI>().SetActiveUnit("enemy");

            battleState = BattleState.Selection;
        }
    }

    






























    void UnitTurn(Pokemon Unit)
    {
        if (Unit == Player)
        {
            Debug.Log("Player Turn");

            //Start Selection
            battleState = BattleState.PlayerTurn;
        } 
        else if (Unit == Enemy)
        {
            Debug.Log("Enemy Turn");

            //AI Choice
            battleState = BattleState.EnemyTurn;

            if (Random.Range(0, 2) == 0)
            {
                StartCoroutine(Attack(Enemy, Player));

                Debug.Log("Enemy chose attack");
            }
            else
            {
                StartCoroutine(Heal(Enemy, Player));
                Debug.Log("Enemy chose attack");
            }
        }
    }


    public void OnButtonAttack()
    {
        if (battleState == BattleState.PlayerTurn)
        {
            Debug.Log("Player chose attack");

            StartCoroutine(Attack(Player, Enemy));
        }
    }*/

    IEnumerator Attack(Pokemon UnitAttacker, Pokemon UnitDefender)
    {
        yield return new WaitForSeconds(0.1f);

        if (BattleUI.GetComponent<BattleUI>().AttackMove(UnitDefender, UnitAttacker))
        {
            if (UnitAttacker == Player)
            {
                battleState = BattleState.BattleWon;

                Debug.Log("Player has won the Battle!");
            }
            else
            {
                battleState = BattleState.BattleLost;

                Debug.Log("Player has lost the Battle!");
            }
        }
    }
    /*
    public void OnButtonHeal()
    {
        if (battleState == BattleState.PlayerTurn)
        {
            Debug.Log("Player chose heal");

            StartCoroutine(Heal(Player, Enemy));
        }
    }
    */
    IEnumerator Heal(Pokemon UnitAttacker, Pokemon UnitDefender)
    {
        yield return new WaitForSeconds(0.1f);

        BattleUI.GetComponent<BattleUI>().HealMove(UnitAttacker);
    }
}
