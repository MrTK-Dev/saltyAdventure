using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonKind : MonoBehaviour
{
    public string Name;
    public Type Type_1;
    public Type Type_2;

    public enum Type
    {
        None,

        Fire,
        Water,
        Grass
    }

    public List<Ability> Abilities;


     
}
