using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shop", menuName = "Market/Shop")]
public class Shop : ScriptableObject
{
    public int ID = 0;

    public Sprite Icon;
    public Sprite BG;

    public string Name = "default Name";
    public string Description = "default Description";
    public string Category = "default Category";

    public List<Item> Stock;
}
