using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonParent : MonoBehaviour
{
    public List<GameObject> ButtonList;

    private void Awake()
    {
        ButtonList = transform.GetChildren();
    }

    public void ActivateAll()
    {
        for (int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].SetActive(true);
        }
    }

    public void DeActivateAll()
    {
        for (int i = 0; i < ButtonList.Count; i++)
        {
            ButtonList[i].SetActive(false);
        }
    }

    /*public void UpdateUI(List<BattleMove> newMoves)
    {
        for (int i = 0; i < newMoves.Count; i++)
        {
            //ButtonList[i].GetComponent<BattleButton>().SetUI(newMoves[i]);
        }
    }*/
}
