using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    #region Singleton

    //public delegate void OnPositionChanged();
    //public OnPositionChanged onPositionChangedCallback;
    public static PlayerMovementController instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject Player;
    
    public int MovementSpeed;
    public int SprintingSpeed;

    public Vector2 PlayerPosition;
    public Vector2 TargetPosition;

    Transform PlayerTransform;

    private void Start()
    {
        PlayerTransform = Player.GetComponent<Transform>();
    }

    private void Update()
    {
        PlayerPosition = new Vector2(PlayerTransform.position.x, PlayerTransform.position.y);
    }
}
