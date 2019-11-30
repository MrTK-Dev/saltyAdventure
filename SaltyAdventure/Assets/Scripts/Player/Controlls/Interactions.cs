using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public List<GameObject> ParentList;

    public GameObject CollidingInteractable;

    void Update()
    {
        //Check for Idle && InputKey
        if (PlayerStateManager.instance.GetPlayerState() == PlayerStateManager.PlayerState.Idle && Input.GetKeyDown(KeyCode.G))
        {
            if (CheckInter() != null)
            {
                InteractionEvent(CollidingInteractable.GetComponent<Interactable>());
            }
        }
    }

    void InteractionEvent(Interactable interactable)
    {
        if (interactable != null)
        {
            //Interactable.PlayerIsInteracting = true;
            interactable.Interact();
        }
    }

    GameObject CheckInter()
    {
        //Check Facing
        if (PlayerStateManager.instance.GetPlayerFacing() == PlayerStateManager.PlayerFacing.Up)
        {
            return LoopLists(Vector2.up);
        }
        else if (PlayerStateManager.instance.GetPlayerFacing() == PlayerStateManager.PlayerFacing.Down)
        {
            return LoopLists(Vector2.down);
        }
        else if (PlayerStateManager.instance.GetPlayerFacing() == PlayerStateManager.PlayerFacing.Left)
        {
            return LoopLists(Vector2.left);
        }
        else if (PlayerStateManager.instance.GetPlayerFacing() == PlayerStateManager.PlayerFacing.Right)
        {
            return LoopLists(Vector2.right);
        }
        else
        {
            return null;
        }

        GameObject LoopLists(Vector2 reqPos)
        {
            CollidingInteractable = null;

            //targeted tile
            Vector2 newVector = PlayerMovementController.instance.PlayerPosition + reqPos;

            //loop through parentlist
            for (int i = 0; i < ParentList.Count; i++)
            {
                for (int j = 0; j < ParentList[i].GetComponentsInChildren<SpriteRenderer>().Length; j++)
                {
                    if (ParentList[i].GetComponentsInChildren<SpriteRenderer>()[j].transform.position == new Vector3(newVector.x, newVector.y, 0))
                    {
                        CollidingInteractable = ParentList[i].GetComponentsInChildren<SpriteRenderer>()[j].gameObject;
                        break;
                    }
                }
            }

            return CollidingInteractable;
        }
    }
}
