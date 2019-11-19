using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public GameObject ItemParent;
    SpriteRenderer[] ItemList;

    public GameObject NPCParent;
    SpriteRenderer[] NPCList;

    public GameObject CollidingInteractable;

    private void Start()
    {
        UpdateLists();
    }

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

    void UpdateLists()
    {
        ItemList = ItemParent.GetComponentsInChildren<SpriteRenderer>();
        NPCList = NPCParent.GetComponentsInChildren<SpriteRenderer>();
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
            //Update Lists
            UpdateLists();

            CollidingInteractable = null;

            //targeted tile
            Vector2 newVector = PlayerMovementController.instance.PlayerPosition + reqPos;

            //Loop through Lists
            for (int i = 0; i < ItemList.Length; i++)
            {
                //Itemlist
                if (ItemList[i].transform.position == new Vector3(newVector.x, newVector.y, 0))
                {
                    CollidingInteractable = ItemList[i].gameObject;
                }
            }

            if (CollidingInteractable == null)
            {
                for (int i = 0; i < NPCList.Length; i++)
                {
                    //NPClist
                    if (NPCList[i].transform.position == new Vector3(newVector.x, newVector.y, 0))
                    {
                        CollidingInteractable = NPCList[i].gameObject;
                    }
                }
            }


            return CollidingInteractable;
        }
    }
}
