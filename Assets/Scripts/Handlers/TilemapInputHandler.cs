using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapInputHandler : MonoBehaviour
{

    BuildController buildController;
    [SerializeField] Tilemap foregroundTilemap;

    // Start is called before the first frame update
    void Start()
    {
        buildController = FindObjectOfType<BuildController>();        
    }
    
    public void OnMouseDown()
    {
        Debug.Log("on tilemap mouse down");

        Vector3Int tilemapPos = MouseToGridPosition();
        Debug.Log("tilemap mouse down: " + tilemapPos);

        buildController.TilemapClicked(foregroundTilemap, tilemapPos);
    }

    public Vector3Int MouseToGridPosition()
    {
       return foregroundTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
