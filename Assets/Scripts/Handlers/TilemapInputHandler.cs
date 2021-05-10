using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapInputHandler : MonoBehaviour
{

    BuildController _buildController;
    private BuildingIndicatorController _buildingIndicatorController;
    [SerializeField] Tilemap foregroundTilemap;
    
    // Start is called before the first frame update
    void Start()
    {
        _buildController = FindObjectOfType<BuildController>();     
        _buildingIndicatorController = FindObjectOfType<BuildingIndicatorController>();

    }

    private void OnMouseOver()
    {
        _buildingIndicatorController.SetPosition((Vector2Int)MouseToGridPosition());
    }

    public void OnMouseDown()
    {
        Debug.Log("on tilemap mouse down");

        Vector3Int tilemapPos = MouseToGridPosition();
        Debug.Log("tilemap mouse down: " + tilemapPos);

        _buildController.TilemapClicked(foregroundTilemap, tilemapPos);
    }

    public Vector3Int MouseToGridPosition()
    {
       return foregroundTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
