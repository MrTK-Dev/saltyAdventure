using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Poke", menuName = "Pokemon")]
public class Pokemon : ScriptableObject
{
    public string Name;
    public int maxHP;
    public int currentHP;
    public int Level;

    public int Speed;
}
