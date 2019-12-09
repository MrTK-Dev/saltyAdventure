using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    /*public GameObject BattleStationController;
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
            activeUnit = BattleUI.GetComponent<BattleUI>().PlayerHUD;
            passiveUnit = BattleUI.GetComponent<BattleUI>().EnemyHUD;

            PlayerMove();

            yield return new WaitForSeconds(2f);

            EnemyMove();
        }
        else
        {
            activeUnit = BattleUI.GetComponent<BattleUI>().PlayerHUD;
            passiveUnit = BattleUI.GetComponent<BattleUI>().EnemyHUD;

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
    }*/


























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

    /*IEnumerator Attack(Pokemon UnitAttacker, Pokemon UnitDefender)
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
    }*/
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
    /*IEnumerator Heal(Pokemon UnitAttacker, Pokemon UnitDefender)
    {
        yield return new WaitForSeconds(0.1f);

        BattleUI.GetComponent<BattleUI>().HealMove(UnitAttacker);
    }*/

    #region Singleton

    public static BattleManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject BattleUI;
    public GameObject Player;
    public GameObject Enemy;

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

    //Cache
    GameObject ActiveUnit;
    GameObject PassiveUnit;

    private void Start()
    {
        //BattleState
        battleState = BattleState.Selection;

        //reset HP  //test
        Player.GetComponent<UnitHUD>().ResetHP();
        Enemy.GetComponent<UnitHUD>().ResetHP();

        //Instantiate UI
        BattleUI.GetComponent<BattleUI>().InstantiateUI();
        BattleUI.GetComponent<BattleUI>().InstantiateSelection();
    }

    public void StartRound(BattleMove Player_Move)
    {
        float PauseDuration = 5f;

        BattleMove PlayerMove = Player_Move;
        BattleMove EnemyMove = RandomizeEnemy();

        BattleMove RandomizeEnemy()
        {
            int MoveInt = Random.Range(0, Enemy.GetComponent<UnitHUD>().Moves.Count);

            return Enemy.GetComponent<UnitHUD>().Moves[MoveInt];
        }

        battleState = BattleState.Idle;

        Debug.Log("Player chose " + Player_Move.Name);

        BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().DeActivateUI();

        StartCoroutine(Attacks());

        IEnumerator Attacks()
        {
            //check for Speed
            if (Player.GetComponent<UnitHUD>().PKMN.Speed > Enemy.GetComponent<UnitHUD>().PKMN.Speed)
            {
                battleState = BattleState.PlayerTurn;
                ExecuteMove(Player, PlayerMove);

                yield return new WaitForSeconds(PauseDuration);

                battleState = BattleState.EnemyTurn;
                ExecuteMove(Enemy, EnemyMove);
            }

            else
            {
                battleState = BattleState.EnemyTurn;
                ExecuteMove(Enemy, EnemyMove);

                yield return new WaitForSeconds(PauseDuration);

                battleState = BattleState.PlayerTurn;
                ExecuteMove(Player, PlayerMove);
            }

            yield return new WaitForSeconds(PauseDuration);

            battleState = BattleState.Selection;

            BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().ActivateUI();
        }

        void ExecuteMove(GameObject Unit, BattleMove Move)
        {
            ActiveUnit = Unit;
            PassiveUnit = GetPassiveUnit();

            GameObject GetPassiveUnit()
            {
                if (ActiveUnit == Player)
                    return Enemy;
                else
                    return Player;
            }

            //ToDO
            //Use a better Way of switching Moves
            if (Move.Name == "Attack")
            {
                int Dmg = Random.Range(0, 50);

                StartCoroutine(AttackMove(PassiveUnit, Dmg));

                BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().InstantiateSFText(
                    ActiveUnit.GetComponent<UnitHUD>().PKMN.Name + " has used " + Move.Name + 
                    " and made " + Dmg + " Damage to " + PassiveUnit.GetComponent<UnitHUD>().PKMN.Name
               );
            }
            else if (Move.Name == "Heal")
            {
                StartCoroutine(HealMove(ActiveUnit));

                BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().InstantiateSFText(
                    ActiveUnit.GetComponent<UnitHUD>().PKMN.Name + " has healed itself by 10 HP"
                );
            }
        }

        IEnumerator AttackMove(GameObject PassiveUnit, int Dmg)
        {
            for (int i = 0; i < Dmg; i++)
            {
                PassiveUnit.GetComponent<UnitHUD>().PKMN.currentHP--;
                //PassiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().GetComponent<Slider>().value--;
                PassiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().AttackAnimation();
                PassiveUnit.GetComponent<UnitHUD>().HP.text = PassiveUnit.GetComponent<UnitHUD>().PKMN.currentHP.ToString() + "/" + PassiveUnit.GetComponent<UnitHUD>().PKMN.maxHP.ToString();

                if (PassiveUnit.GetComponent<UnitHUD>().PKMN.currentHP == 0)
                {
                    OnDeath();

                    break;
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

        IEnumerator HealMove(GameObject ActiveUnit)
        {
            for (int i = 0; i < 10; i++)
            {
                if (ActiveUnit.GetComponent<UnitHUD>().PKMN.currentHP == ActiveUnit.GetComponent<UnitHUD>().PKMN.maxHP)
                    break;

                ActiveUnit.GetComponent<UnitHUD>().PKMN.currentHP++;
                //ActiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().GetComponent<Slider>().value++;
                ActiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().HealAnimation();
                ActiveUnit.GetComponent<UnitHUD>().HP.text = ActiveUnit.GetComponent<UnitHUD>().PKMN.currentHP.ToString() + "/" + ActiveUnit.GetComponent<UnitHUD>().PKMN.maxHP.ToString();

                yield return new WaitForSeconds(0.2f);
            }
        }

        void OnDeath()
        {
            Debug.Log(PassiveUnit.GetComponent<UnitHUD>().PKMN.Name + " is dead");

            StopAllCoroutines();

            StartCoroutine(DeathScreen());

            IEnumerator DeathScreen()
            {
                BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().InstantiateSFText(PassiveUnit.GetComponent<UnitHUD>().PKMN.Name + " is dead");

                yield return new WaitForSeconds(2f);

                BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().InstantiateSFText(ActiveUnit.GetComponent<UnitHUD>().PKMN.Name + " has won the Battle");

                yield return new WaitForSeconds(2f);
            }
        }
    }
}