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

    public List<GameObject> ParentList;

    public Grid MapGrid;

    Tilemap[] TileMapList;

    private void Start()
    {
        UpdateLists();
    }

    void UpdateLists()
    {
        TileMapList = MapGrid.GetComponentsInChildren<Tilemap>();
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

        //check interactable sprites
        if (!isCollider)
        {
            for (int i = 0; i < ParentList.Count; i++)
            {
                for (int j = 0; j < ParentList[i].GetComponentsInChildren<SpriteRenderer>().Length; j++)
                {
                    if (ParentList[i].GetComponentsInChildren<SpriteRenderer>()[j].transform.position == new Vector3(RequestedPos.x, RequestedPos.y, 0))
                    {
                        isCollider = true;
                        break;
                    }
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
