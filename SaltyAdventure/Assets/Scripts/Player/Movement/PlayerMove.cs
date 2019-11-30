using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform PlayerTransform;
    float ActualSpeed;

    Vector2 newPos;

    private void Start()
    {
        ActualSpeed = PlayerMovementController.instance.MovementSpeed * Time.deltaTime;
    }

    void Update()
    {

        //check for Idle State
        if (PlayerStateManager.instance.GetPlayerState() == PlayerStateManager.PlayerState.Idle)
        {
            if (Input.GetKey(KeyCode.W))
            {
                PlayerStateManager.instance.setFacing(PlayerStateManager.PlayerFacing.Up);

                ChangeDirection(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                PlayerStateManager.instance.setFacing(PlayerStateManager.PlayerFacing.Down);

                ChangeDirection(Vector2.down);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                PlayerStateManager.instance.setFacing(PlayerStateManager.PlayerFacing.Left);

                ChangeDirection(Vector2.left);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                PlayerStateManager.instance.setFacing(PlayerStateManager.PlayerFacing.Right);

                ChangeDirection(Vector2.right);
            }
        }

        //Sprinting
        else if (PlayerStateManager.instance.GetPlayerState() == PlayerStateManager.PlayerState.Walking || PlayerStateManager.instance.GetPlayerState() == PlayerStateManager.PlayerState.Sprinting)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ActualSpeed = PlayerMovementController.instance.SprintingSpeed * Time.deltaTime;
                PlayerStateManager.instance.currentPlayerState = PlayerStateManager.PlayerState.Sprinting;
            } else
            {
                ActualSpeed = PlayerMovementController.instance.MovementSpeed * Time.deltaTime;
                PlayerStateManager.instance.currentPlayerState = PlayerStateManager.PlayerState.Walking;
            }
        }

        Move();
    }


    void ChangeDirection(Vector2 Direction)
    {
        newPos = PlayerMovementController.instance.TargetPosition + Direction;

        if (!PlayerMap.instance.CreateMap(newPos))
        {
            if (PlayerStateManager.instance.GetPlayerState() != PlayerStateManager.PlayerState.Walking && PlayerStateManager.instance.GetPlayerState() != PlayerStateManager.PlayerState.Sprinting)
            {
                PlayerMovementController.instance.TargetPosition = newPos;
                PlayerStateManager.instance.setState(PlayerStateManager.PlayerState.Walking);
            }
        }
    }

    void Move()
    {
        if (PlayerStateManager.instance.GetPlayerState() == PlayerStateManager.PlayerState.Walking || PlayerStateManager.instance.GetPlayerState() == PlayerStateManager.PlayerState.Sprinting)
        {
            PlayerTransform.position = Vector2.MoveTowards(PlayerTransform.position, PlayerMovementController.instance.TargetPosition, ActualSpeed);
            if (PlayerMovementController.instance.PlayerPosition == PlayerMovementController.instance.TargetPosition)
            {
                //Check for Trigger
                PlayerMap.instance.CheckForTrigger();

                //set Idle
                PlayerStateManager.instance.currentPlayerState = PlayerStateManager.PlayerState.Idle;
            }
        }
    } 
}
