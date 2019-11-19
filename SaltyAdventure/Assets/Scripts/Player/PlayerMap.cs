using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMap : MonoBehaviour
{
    #region Singleton

    public static PlayerMap instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public Grid MapGrid;
    public GameObject ItemParent;

    Tilemap[] TileMapList;
    SpriteRenderer[] ItemList;

    private void Start()
    {
        UpdateLists();
    }

    void UpdateLists()
    {
        TileMapList = MapGrid.GetComponentsInChildren<Tilemap>();
        ItemList = ItemParent.GetComponentsInChildren<SpriteRenderer>();
    }

    public bool CreateMap(Vector2 RequestedPos)
    {
        UpdateLists();

        //Movement

        bool isCollider = false;

        //Loop through Tilemaps
        for (int i = 0; i < TileMapList.Length; i++)
        {
            if (TileMapList[i].HasTile(new Vector3Int(Mathf.RoundToInt(RequestedPos.x - 1), Mathf.RoundToInt(RequestedPos.y - 1), 0)))
            {
                isCollider = TileMapList[i].CompareTag("Collidable");
            }
        }

        if (!isCollider)
        {
            //Check for Items
            for (int i = 0; i < ItemList.Length; i++)
            {
                if (ItemList[i].transform.position == new Vector3(RequestedPos.x, RequestedPos.y, 0))
                {
                    isCollider = true;
                }
            }
        }

        //return bool
        return isCollider;
    }

    public void CheckForTrigger()
    {
        for (int i = 0; i < TileMapList.Length; i++)
        {
            if (TileMapList[i].HasTile(new Vector3Int(Mathf.RoundToInt(PlayerMovementController.instance.PlayerPosition.x - 1), Mathf.RoundToInt(PlayerMovementController.instance.PlayerPosition.y - 1), 0)))
            {
                //Grass Trigger
                if (TileMapList[i].CompareTag("Grass"))
                {
                    GroundTrigger.instance.GrassTrigger();
                }
            }
        }
    }

}
