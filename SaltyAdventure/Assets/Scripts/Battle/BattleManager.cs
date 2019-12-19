using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
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

    public void StartRound()
    {
        //float PauseDuration = 5f;

        //BattleMove PlayerMove = Player_Move;
        //BattleMove EnemyMove = RandomizeEnemy();

        //BattleMove RandomizeEnemy()
        //{
        //    int MoveInt = Random.Range(0, Enemy.GetComponent<UnitHUD>().Moves.Count);
        //
        //    return Enemy.GetComponent<UnitHUD>().Moves[MoveInt];
        //}

        /*battleState = BattleState.Idle;

        //Debug.Log("Player chose " + Player_Move.Name);

        BattleUI.GetComponent<BattleUI>().SelectionField.GetComponent<SelectionField>().DeActivateUI();

        StartCoroutine(Attacks());

        IEnumerator Attacks()
        {
            //check for Speed
            if (Player.GetComponent<BasePokemon>().LiveStats.Speed > Enemy.GetComponent<BasePokemon>().LiveStats.Speed)
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
                int Dmg = Random.Range(5, 10);

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
            Debug.Log(PassiveUnit.name + " gets inflicted with " + Dmg);

            for (int i = 0; i < Dmg; i++)
            {
                PassiveUnit.GetComponent<BasePokemon>().LiveStats.HP--;
                //PassiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().GetComponent<Slider>().value--;
                PassiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().AttackAnimation();
                PassiveUnit.GetComponent<UnitHUD>().HP.text = PassiveUnit.GetComponent<BasePokemon>().LiveStats.HP.ToString() + "/" + PassiveUnit.GetComponent<BasePokemon>().Stats.HP.ToString();

                if (PassiveUnit.GetComponent<BasePokemon>().LiveStats.HP == 0)
                {
                    OnDeath();

                    break;
                }

                yield return new WaitForSeconds(0.1f);
            }

            Debug.Log(PassiveUnit.name + " has now " + PassiveUnit.GetComponent<BasePokemon>().LiveStats.HP + "hp");
        }

        IEnumerator HealMove(GameObject ActiveUnit)
        {
            for (int i = 0; i < 5; i++)
            {
                if (ActiveUnit.GetComponent<BasePokemon>().LiveStats.HP == ActiveUnit.GetComponent<BasePokemon>().Stats.HP)
                    break;

                ActiveUnit.GetComponent<BasePokemon>().LiveStats.HP++;
                //ActiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().GetComponent<Slider>().value++;
                ActiveUnit.GetComponent<UnitHUD>().Slider.GetComponent<SliderHP>().HealAnimation();
                ActiveUnit.GetComponent<UnitHUD>().HP.text = ActiveUnit.GetComponent<BasePokemon>().LiveStats.HP.ToString() + "/" + ActiveUnit.GetComponent<BasePokemon>().Stats.HP.ToString();

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
        }*/
    }
}