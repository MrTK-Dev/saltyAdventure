using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "Battle/Move")]
public class BattleMove : ScriptableObject
{
    public string Name;
    public virtual void Execute()
    {
        Debug.Log(Name + "has been used");
    }
}
