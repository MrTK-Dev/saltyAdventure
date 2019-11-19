using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    #region Singleton

    public static PlayerStateManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public enum PlayerState
    {
        //Movement
        Idle,
        Walking,
        Sprinting,

        //Interaction
        Speaking,
        Interacting,

        //Menus
        Inventory,
        Menu
    }

    public enum PlayerFacing
    {
        Up,
        Down,
        Left,
        Right
    }

    public PlayerState currentPlayerState = PlayerState.Idle;
    public PlayerState requestedPlayerState = PlayerState.Idle;

    public PlayerFacing currentPlayerFacing = PlayerFacing.Down;

    public PlayerState GetPlayerState()
    {
        return currentPlayerState;
    }

    public PlayerFacing GetPlayerFacing()
    {
        return currentPlayerFacing;
    }

    public void setState(PlayerState newPlayerState)
    {
        if (newPlayerState != currentPlayerState)
        {
            currentPlayerState = newPlayerState;
        }
    }

    public void setFacing(PlayerFacing newPlayerFacing)
    {
        if (newPlayerFacing != currentPlayerFacing)
        {
            currentPlayerFacing = newPlayerFacing;
        }
    }
}
