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

    [SerializeField] TileData selectedTile;  //TO DO Remove serialize field    

    ResourceController resourceController;

    // Start is called before the first frame update
    void Start()
    {
        resourceController = FindObjectOfType<ResourceController>();

        //Debug.Log(foregroundTilemap.cellBounds);
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
        return selectedTile.tile;
    }

    public void SetSelectedTile(TileData _selectedTile)
    {
        selectedTile = _selectedTile;
        Debug.Log("Selected tile: " + selectedTile.name);
    }

    public void TilemapClicked(Tilemap tilemap, Vector3Int tilemapPos)
    {
        if (!selectedTile)
            Debug.LogError("No tile selected!");


        if(resourceController.EnoughCredits(selectedTile.tileCost))
        {
            //can buy:

            TileBase newTile = Instantiate<TileBase>(selectedTile.tile);
            tilemap.SetTile(tilemapPos, newTile);

            resourceController.SpendCredits(selectedTile.tileCost);            
        }

    }


}
