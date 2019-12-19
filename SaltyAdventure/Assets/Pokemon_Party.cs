using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pokemon_Party
{
    static public BasePokemon[] List = new BasePokemon[6];
    static public int Count;

    static void CheckForSpace()
    {
        int Counter = 0;

        for (int i = 0; i < List.Length; i++)
        {
            if (List[i] != null)
            {
                Counter++;
            }
        }

        Count = Counter;
    }

    static public void AddPokemonToParty(BasePokemon Pokemon)
    {
        CheckForSpace();

        if (Count >= 6)
        {
            Debug.Log("Party is full; " + Pokemon.Name + " could not get added.");
        }

        else
        {
            for (int i = 0; i < List.Length; i++)
            {
                if (List[i] == null)
                {
                    List[i] = Pokemon;

                    break;
                }
            }
        }
    }

    static public void RemovePokemonFromParty(BasePokemon Pokemon)
    {
        for (int i = 0; i < List.Length; i++)
        {
            if (List[i] == Pokemon)
            {
                List[i] = null;

                break;
            }
        }
    }

    static public BasePokemon GetPokemonData(int Index, bool remove)
    {
        if (Index > 5 || Index < 0)
        {
            throw new System.Exception(Index + " is not in Bound. Please use a Number between 0 - 5");
        }

        if (remove)
        {
            RemovePokemonFromParty(List[Index]);
        }

        return List[Index];
    }

    static public BasePokemon GetPokemonData(Monster Monster)
    {
        for (int i = 0; i < List.Length; i++)
        {
            if (List[i].Monster == Monster)
            {
                return List[i];
            }
        }

        Debug.Log("Requested Pokemon is not in the Party");
        return null;
    }

    static public List<BasePokemon> GetPokemonList()
    {
        List<BasePokemon> newList = new List<BasePokemon>();

        for (int i = 0; i < List.Length; i++)
        {
            if (List[i] != null)
            {
                newList.Add(List[i]);
            }
        }

        return newList;
    }

    static public bool IsPokemonInParty(Monster Monster)
    {
        for (int i = 0; i < List.Length; i++)
        {
            if (List[i].Monster == Monster)
            {
                return true;
            }
        }

        return false;
    }

    static public int GetCount()
    {
        CheckForSpace();

        return Count;
    }
}
