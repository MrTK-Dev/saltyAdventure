using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "NPCS/Conversation")]
public class Conversation : ScriptableObject
{
    public string[] ConversationText;
}
