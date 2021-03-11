using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildController : MonoBehaviour
{
    //Board management
    //[Tooltip("Area board size")]
    [SerializeField] public int boardSizeX = 6;
    [SerializeField] public int boardSizeY = 12;

    [SerializeField] Tilemap foregroundTilemap; //TO DO needed?

    [SerializeField] TileBase selectedTile; //TO DO receive from button Scriptable Object
    [SerializeField] int buildCost; //TO DO receive from button Scriptable Object

    ResourceController resourceController;

    // Start is called before the first frame update
    void Start()
    {
        resourceController = FindObjectOfType<ResourceController>();

        Debug.Log(foregroundTilemap.cellBounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tilemap GetForegroundTilemap()
    {
        return foregroundTilemap;
    }

    public TileBase GetSelectedTile()
    {
        return selectedTile;
    }

    public void TilemapClicked(Tilemap tilemap, Vector3Int tilemapPos)
    {
        if(resourceController.EnoughCredits(buildCost))
        {
            //can buy:

            TileBase newTile = Instantiate<TileBase>(selectedTile);
            tilemap.SetTile(tilemapPos, newTile);

            resourceController.SpendCredits(buildCost);            
        }

    }


}
