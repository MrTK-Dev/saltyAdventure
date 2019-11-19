using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    //ID System depending on category/type
    public int ID = 0;
    public int Price = 0;

    public Sprite icon;

    new public string name = "default Item";
    public string description = "default Description";

    public string type = "default type";

    public string category = "default type";

    public int StackSize = 1;

    public virtual void Use ()
    {
        Debug.Log("Using " + name);
    }
}
    
