using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "New Tile")]
public class TileData : ScriptableObject
{
    public enum TileType { Wall, Door, Other } // TO DO This needs to be dinamically managed
    
    public TileType tileType;
    public Tile tile;
    public Sprite tileSprite;
    public GameObject dragImagePrefab;
    public int tileCost;
    //public int xPos, yPos;

    void Awake()
    {
        tileType = TileType.Wall; // TO DO: Remove...
    }

    void SetTileType(TileType _tileType)
    {
        tileType = _tileType;
    }


}
