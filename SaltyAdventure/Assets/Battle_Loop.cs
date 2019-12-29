using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public static class Battle_Loop
{
    static BasePokemon PlayerPokemon;
    static BasePokemon EnemyPokemon;

    static Move PlayerMove = Move.none;
    static Move EnemyMove = Move.none;

    public static void InstantiateRound(BasePokemon newPlayerPokemon, Move newPlayerMove, BasePokemon newEnemyPokemon)
    {
        PlayerPokemon = newPlayerPokemon;
        EnemyPokemon = newEnemyPokemon;

        PlayerMove = newPlayerMove;
        EnemyMove = GetEnemyMove(EnemyPokemon.Moves);

        Move[] PriorityList = GetPriority();

        Move first = PriorityList[0];
        Move second = PriorityList[1];

        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, first.ToString());
        Logger.Debug(MethodBase.GetCurrentMethod().DeclaringType, second.ToString());
    }

    static Move GetEnemyMove(BaseMove[] Moves)
    {
        /*BaseMove newMove = GetMove(GetRN());

        if (newMove == null || newMove.isDisabled || newMove.CurrentPP == 0)
        {
            
        }

        return newMove.Move;

        int GetRN()
        {
            return Random.Range(0, Moves.Length);
        }

        BaseMove GetMove(int Index)
        {
            if (Moves[Index] != null)
                return Moves[Index];

            else
                return null;
        }*/

        List<BaseMove> newList = new List<BaseMove>();

        for (int i = 0; i < Moves.Length; i++)
        {
            if (Moves[i] != null)
                newList.Add(Moves[i]);
        }

        return newList[Random.Range(0, newList.Count - 1)].Move;
    }

    static Move[] GetPriority()
    {
        Move[] newMoves = new Move[2];

        if (MoveData.GetData(PlayerMove).Priority != MoveData.GetData(EnemyMove).Priority)
        {
            if (MoveData.GetData(PlayerMove).Priority > MoveData.GetData(EnemyMove).Priority)
            {
                newMoves[0] = PlayerMove;
                newMoves[1] = EnemyMove;
            }

            else
            {
                newMoves[1] = PlayerMove;
                newMoves[0] = EnemyMove;
            }
        }

        else if (PlayerPokemon.LiveStats.Speed != EnemyPokemon.LiveStats.Speed)
        {
            if (PlayerPokemon.LiveStats.Speed > EnemyPokemon.LiveStats.Speed)
            {
                newMoves[0] = PlayerMove;
                newMoves[1] = EnemyMove;
            }

            else
            {
                newMoves[1] = PlayerMove;
                newMoves[0] = EnemyMove;
            }
        }

        else
        {
            int RN = Random.Range(0, 2);

            if (RN == 0)
            {
                newMoves[0] = PlayerMove;
                newMoves[1] = EnemyMove;
            }

            else
            {
                newMoves[1] = PlayerMove;
                newMoves[0] = EnemyMove;
            }
        }

        return newMoves;
    }
}

